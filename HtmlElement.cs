using Serializer1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer1
{
    public class HtmlElement
    {
        // Properties to hold various aspects of the HTML element
        public string Name { get; set; }
        public string Id { get; set; }
        public List<string> Attributes { get; set; }
        public List<string> Classes { get; set; }
        public string InnerHtml { get; set; }
        public HtmlElement Parent { get; set; }
        public List<HtmlElement> Children { get; set; }

        public HtmlElement()
        {
            Attributes = new List<string>();
            Classes = new List<string>();
            Parent = null;
            Children = new List<HtmlElement>();
        }

        // Method to get all descendants of the element
        public IEnumerable<HtmlElement> Descendants()
        {
            Queue<HtmlElement> queue = new Queue<HtmlElement>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                HtmlElement currentElement = queue.Dequeue();
                foreach (var child in currentElement.Children)
                {
                    queue.Enqueue(child);
                }
                yield return currentElement;
            }
        }

        // Method to get all ancestors of the element
        public IEnumerable<HtmlElement> Ancestors()
        {
            HtmlElement child = this;
            while (child.Parent != null)
            {
                yield return child.Parent;
                child = child.Parent;
            }
        }
    }
}
