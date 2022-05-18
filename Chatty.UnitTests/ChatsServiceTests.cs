using NUnit.Framework;

namespace Chatty.UnitTests
{
    public class ChatsServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Chats_GetChatsForExistingUser_HappyPath()
        {
            Assert.Fail();
        }

        [Test]
        public void Chats_GetChatsForUserWhenUserIsNull_ThrowArgumentNullException()
        {
            Assert.Fail();
        }

        [Test]
        public void Chats_GetChatsForNotExisting_ThrowKeyNotFoundException()
        {
            Assert.Fail();
        }

        [Test]
        public void Chats_DeleteChatForGivenUsersWithUserNotFound_ThrowKeyNotFoundException()
        {
            Assert.Fail();
        }

        [Test]
        public void Chats_DeleteChatForGivenUsers_HappyPath()
        {
            Assert.Fail();
        }

        [Test]
        public void Chats_DeleteChatForGivenUsersWithFirstUserIsNull_ThrowArgumentNullException()
        {
            Assert.Fail();
        }

        [Test]
        public void Chats_DeleteChatForGivenUsersWithSecondUserIsNull_ThrowArgumentNullException()
        {
            Assert.Fail();
        }
    }
}