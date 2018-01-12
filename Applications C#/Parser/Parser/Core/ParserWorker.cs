using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
        class ParserWorker<T> where T : class
        {
            IParser<T> parser;
            IParserSettings settings;
            HtmlLoader loader;

            public IParser<T> Parser
            {
                get => parser;
                set => parser = value;
            }

            public event Action<object, T> OnNeWData;
            public event Action<object> OnCompleted;

            public IParserSettings Settings
            {
                get => settings;
                set
                {
                    settings = value;
                    loader = new HtmlLoader(value);
                }
            }

            public ParserWorker(IParser<T> parser)
            {
                this.parser = parser;
            }
            public ParserWorker(IParser<T> parser, IParserSettings settings) : this(parser)
            {
                this.settings = settings;
            }

            public void Start()
            {
                isActive = true;
                Worker();
            }

            public void Abort()
            {
                isActive = false;
            }

            bool isActive;

            public bool IsActive { get => isActive; }

            private async void Worker()
            {
                for (int i = settings.StartPoint; i <= settings.EndPoint; i++)
                {
                    if (!isActive)
                    {
                        OnCompleted?.Invoke(this);
                        return;
                    }
                    var source = await loader.GetSourceByPageId(i);
                    var domParser = new HtmlParser();

                    var document = await domParser.ParseAsync(source);

                    var result = parser.Parse(document);

                    OnNeWData?.Invoke(this, result);
                }

                OnCompleted?.Invoke(this);
                isActive = false;
            }
        }
}
