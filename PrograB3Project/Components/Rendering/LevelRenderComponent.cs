using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components.Rendering
{
    public class LevelRenderComponent : RenderComponent
    {
        private int _sizeX = 0;
        private int _sizeY = 0;
        private LocationComponent _ownerLocationComponent;
        private List<VisualRenderComponent> _visualRenderComponentTable = new List<VisualRenderComponent>();
        private VisualRenderComponent _playerRenderComponent;
        private string _levelName;
        public LevelRenderComponent(IGameObject owner, RenderManager render_manager, LocationComponent owner_location_component, int sizeX, int sizeY) : base(owner, render_manager)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _levelName = owner.GetName();
            _ownerLocationComponent = owner_location_component;
        }

        public override void Render()
        {
            
            Console.WriteLine("You are in " + _levelName);
            LocationCoordinates player_coordinates = _playerRenderComponent.GetOwnerTransform().GetLocationCoordinates();
            for (int y_index = 0; y_index < _sizeX; y_index++)
            {
                for (int x_index = 0; x_index < _sizeY; x_index++)
                {
                    if (x_index == 0 || y_index == 0 || x_index == _sizeX - 1 || y_index == _sizeY - 1)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        VisualRenderComponent component_at_location = null;
                        foreach(VisualRenderComponent comp in _visualRenderComponentTable)
                        {
                            LocationCoordinates component_location = comp.GetOwnerTransform().GetLocationCoordinates();
                            if (component_location._xCoordinate == x_index && component_location._yCoordinate == y_index)
                            {
                                component_at_location = comp;
                                break;
                            }
                        }
                        if (player_coordinates._xCoordinate == x_index && player_coordinates._yCoordinate == y_index)
                        {
                            Console.Write(_playerRenderComponent.GetCharacter());
                            
                        }
                        else if (component_at_location != null)
                        {
                            Console.Write(component_at_location.GetCharacter());
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public void AddLocationRenderComponent(VisualRenderComponent renderComponent)
        {
            _visualRenderComponentTable.Add(renderComponent);
        }

        public void SetPlayerVisualRendererComponent(VisualRenderComponent player_comp)
        {
            _playerRenderComponent = player_comp;
        }
    }
}
