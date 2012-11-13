using System.Collections.Generic;

namespace Sushi
{
    public interface ISushiContainer
    {
        ICollection<ISushiComponentBuilder> ContainerElements { get; }
    }
}
