using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookMan.ConsoleApp.Framework.ViewBase;

namespace BookMan.ConsoleApp.Framework
{
    public class ControlBase
    {
        public virtual void Render(ViewBase view) { view.Render(); }
        public virtual void Render<T>(ViewBase<T> view, string path = "", bool both = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                view.Render();
                return;
            }
            if (both)
            {
                view.Render();
                view.RenderToFile(path);
                return;
            }
            view.RenderToFile(path);
        }
        public virtual void Render(Message message) => Render(new MessageView(message));
        public virtual void Success(string text, string label = "SUCCESS") => Render(new Message { Type = MessageType.Success, Text = text, Label = label });
        public virtual void Information(string text, string label = "INFORMATION") => Render(new Message { Type = MessageType.Information, Text = text, Label = label });
        public virtual void Error(string text, string label = "ERROR") => Render(new Message { Type = MessageType.Error, Text = text, Label = label });
        public virtual void Confirmation(string text, string label = "CONFIRMATION") => Render(new Message { Type = MessageType.Confirmation, Text = text, Label = label });
    }


}
