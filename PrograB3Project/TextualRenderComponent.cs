using PrograB3Project.Components;
using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
{
    internal class TextualRenderComponent : RenderComponent
    {
        private string _text = "";
        private string[] _formatedText;
        public TextualRenderComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager, string text, RenderManager render_manager) : base(owner, engine, event_manager, render_manager)
        {
            _text = text;
            try
            {
                _formatedText = _text.Split(".");
            }
            catch 
            {
                _formatedText[0] = "ERROR : Text could not be split or is invalid";
            }
        }

        public override void Render()
        {
            foreach (string line in _formatedText)
            {
                Console.WriteLine(line);
            }
        }
    }
}
