using System.Collections.Generic;

namespace Sushi.Helpers
{
    public interface ISushiContainer
    {
        ICollection<ISushiComponentBuilder> ContainerElements { get; }
    }
}
