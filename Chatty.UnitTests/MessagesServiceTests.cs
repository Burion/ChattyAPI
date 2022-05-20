using AutoMapper;
using ChattyServices.Interfaces;
using ChattyServices.Services;
using NUnit.Framework;
using Moq;
using ChattyDAL.Models;
using ChattyServices.Dtos;
using System;
using ChattyAPI.Helpers;
using ChattyDAL.Interfaces;

namespace Chatty.UnitTests
{
    public class MessagesServiceTests
    {
        private IMessagesService _messagesService;
        private Message message;
        private MessageDto messageDto;
        [SetUp]
        public void Setup()
        {
            message = new Message()
            {
                AuthorId = "author_login",
                ReceiverId = "receiver_login",
                SendingDate = new DateTime(2022, 1, 1),
                Text = "message_text"
            };

            messageDto = new MessageDto()
            {
                Author = "author_login",
                Text = "message_text"
            };

            var mapperConfig = new MapperConfiguration(mc =>
            {
                var profile = new MappingProfile();
                mc.AddProfile(profile);
            });

            var mapper = mapperConfig.CreateMapper();

            var messageDataAccesser = new Mock<IMessagesAccesser>();
            //messageDataAccesser.Setup(mda => mda.GetMessage(It.IsAny<Message>())).Returns(It.IsAny<Message>());

            var messagesService = new MessagesService(mapper, messageDataAccesser.Object);    
        }

        [Test]
        public void Messages_Create_HappyPath()
        {
            
        }

        [Test]
        public void Messages_CreateWithUserIsNull_ThrowInvalidOperationException()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Messages_CreateWhenModelIsNull_ThrowArgumentNullException()
        {
            Assert.Fail();
        }

        [Test]
        public void Messages_Delete_HappyPath()
        {
            Assert.Fail();
        }

        [Test]
        public void Messages_DeleteWhenModelIsNull_ThrowArgumentNullException()
        {
            Assert.Fail();
        }
    }
}
