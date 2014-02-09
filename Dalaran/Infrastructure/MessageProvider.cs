using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using Dalaran.DAL.Entities;
using Dalaran.DAL.Interfaces;
using Dalaran.Infrastructure.Interfaces;
using WebGrease.Css.Extensions;

namespace Dalaran.Infrastructure
{
    public class MessageProvider : IMessageProvider
    {
        private readonly IDataRepository _dataRepository;
        public MessageProvider(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        public string GetMessage(string key)
        {
            var applicationMessage = _dataRepository.Select<ApplicationMessage>(
                x => x.KeyName == key
            ).First();

            if (applicationMessage == null)
                return String.Empty;

            return applicationMessage.Message;
        }


        public List<string> GetMessages(string[] keys)
        {
            var applicationMessages = _dataRepository.Select<ApplicationMessage>(
                x => keys.Contains(x.KeyName)
            );

            if (!applicationMessages.Any())
                return null;

            var messages = new List<string>();
            
            applicationMessages.ForEach(
                x => messages.Add(x.Message));

            return messages;
        }
    }
}
