using PrograB3Project.Components.Rendering;

namespace PrograB3Project
{
    public class RenderManager
    {
        private List<RenderComponent> _renderComponentsTable = new List<RenderComponent>();

        public void Render()
        {
            Console.Clear();
            foreach (RenderComponent render_component in _renderComponentsTable)
            {
                render_component.Render();
            }
        }

        public void RegisterRenderComponent(RenderComponent component_to_register)
        {
            if (component_to_register != null && !_renderComponentsTable.Contains(component_to_register))
            {
                _renderComponentsTable.Add(component_to_register);
            }
        }

        public void UnregisterRenderComponent(RenderComponent component_to_unregister)
        {
            if (_renderComponentsTable.Contains(component_to_unregister))
            {
                _renderComponentsTable.Remove(component_to_unregister);
            }
        }

        public int GetRegisteredComponentCount()
        {
            return _renderComponentsTable.Count;
        }
    }
}
