using CODE.Framework.Services.Client;
using CODE.Framework.Wpf.Mvvm;
using Orion.Client.Core.Model;
using ORMFile.DatabaseSpecific;
using ORMFile.EntityClasses;
using ORMFile.HelperClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Windows;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Project.Client.SHAGenerator.Models.Home
{
    public class ShaGeneratorViewModel : ViewModel
    {
        private string input;
        private string output;
        private ObservableCollection<StandardDataList> messages;

        public string Input
        {
            get
            {
                return input;
            }
            set
            {
                if (input == value) return;
                input = value;
                NotifyChanged("Input");

                this.HashCommand.InvalidateCanExecute();
            }
        }
        public string Output
        {
            get
            {
                return output;
            }
            set
            {
                if (output == value) return;
                output = value;
                NotifyChanged("Output");
            }
        }
        public string OutputReducido
        {
            get
            {
                if(Output.Length > 7)
                    return Output.Substring(0,7);
                return string.Empty;
            }
        }
        public ObservableCollection<StandardDataList> Messages
        {
            get
            {
                return messages;
            }
            set
            {
                if (value == messages) return;
                messages = value;
                NotifyChanged("Messages");
            }
        }

        public ViewAction HashCommand { get; private set; }

        public ShaGeneratorViewModel()
        {
            HashCommand = new ViewAction("Hash", execute: (a, o) => { ComputeHash(); }, canExecute: (a, o) => { return !string.IsNullOrWhiteSpace(this.Input); }, brushResourceKey: "CODE.Framework-Icon-Collapsed");

            Actions.Add(HashCommand);
            Actions.Add(new CloseCurrentViewAction(this, beginGroup: true));

            this.Input = string.Empty;
            this.Output = string.Empty;
            this.Messages = new ObservableCollection<StandardDataList>();

            LoadMessages();
        }

        private void LoadMessages()
        {
            AsyncWorker.Execute(
             () =>
             {
                 var result = new EntityCollection<MessageEntity>();
                 try
                 {
                     using(var adapter = new DataAccessAdapter())
                     {
                         adapter.FetchEntityCollection(result, null);
                     }
                 }  
                 catch { }
                 return result;
             },
             (response) =>
             {
                 if (response == null) return;
                 ProcessResponseLoadMessages(response);
             }, this, ModelStatus.Saving);
        }
        private bool SaveMessage(string hash, string message)
        {
            try
            {
                if (DuplicateHash(hash))
                {
                    Controller.Message("Hash duplicado");
                    return false;
                }

                var entity = new MessageEntity()
                {
                    Tag = hash,
                    Message = message,
                    Active = true
                };

                using (var adapter = new DataAccessAdapter())
                {
                    adapter.SaveEntity(entity, false);
                }

                return true;
            }
            catch(Exception ex) 
            {
                Controller.Message(ex.Message);
            }

            return false;
        }
        private bool DuplicateHash(string hash)
        {
            var entity = new MessageEntity();
            using (var adapter = new DataAccessAdapter())
            {
                adapter.FetchEntityUsingUniqueConstraint(entity, new PredicateExpression(MessageFields.Tag == hash));
            }

            return !entity.IsNew;
        }
        private void ProcessResponseLoadMessages(EntityCollection<MessageEntity> response)
        {
            this.Messages.Clear();
            this.Messages.AddRange(
                from m in response.ToList()
                select new StandardDataList()
                {
                    Id = m.Id,
                    Text1 = m.Tag,
                    Text2 = m.Message,
                    IsChecked = m.Active
                });
        }
        
        private void ComputeHash()
        {
            this.Output = GetSHA1HashData(this.Input.Trim());
            NotifyChanged("OutputReducido");

            if (SaveMessage(this.OutputReducido, this.Input.Trim()))
            {
                //Copiar resultado al portapapeles
                var result = this.OutputReducido + "\t" + this.Input.Trim();
                Clipboard.SetText(result);
                Controller.Message(result, "Mensaje persistido y copiado al portapapeles...");

                this.Input = string.Empty;
                this.Output = string.Empty;
                NotifyChanged("OutputReducido");

                LoadMessages();
            }
        }
        private string GetSHA1HashData(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }
        private static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();

            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString();
        }
    }
}
