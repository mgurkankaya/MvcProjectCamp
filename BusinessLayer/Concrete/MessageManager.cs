using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetbyId(int id)
        {
            return _messageDal.Get(x=>x.MessageId==id);
        }



        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@admin.com");
        }

        public List<Message> GetListSendBox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@admin.com");
        }

        public void MessageAddBl(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDeleteBl(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdateBl(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
