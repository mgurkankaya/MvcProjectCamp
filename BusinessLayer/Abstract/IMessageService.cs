using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendBox(string p);
        void MessageAddBl(Message message);

        Message GetbyId(int id);
        void MessageDeleteBl(Message message);
        void MessageUpdateBl(Message message);
    }
}
