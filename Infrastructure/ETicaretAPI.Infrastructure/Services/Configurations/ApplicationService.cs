using ETicaretAPI.Application.Abstractions.Services.Configurations;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.DTOs.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace ETicaretAPI.Infrastructure.Services.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationService : IApplicationService
    {
        public List<Menu> GetAuthorizeDefinitionEndpoints(Type assemblyType)
        {
            // Get the executing assembly
            Assembly? assembly = Assembly.GetAssembly(assemblyType);

            // Retrieves all the types that the assembly contains
            // Filters based on whether they derived from ControllerBase class
            // Returns filtered types in an array as a list
            var controllers = assembly?.GetTypes()
                                        .Where(t => t.IsAssignableTo(typeof(ControllerBase)));
            List<Menu> menus = new();

            // Iterate over each type in controllers array
            foreach (var controller in controllers)
            {
                var menu = new Menu();
                // Retrieve all the action methods defined in the controller decorated with given attribute type and store in a list.
                var actions = controller
                                .GetMethods()
                                .Where(m => m.IsDefined(typeof(AuthorizeDefinitionAttribute)))
                                .ToList();

                if (!actions.Any()) continue; // Skip if no actions

                foreach (var action in actions)
                {
                    var authorizeAttr = action.GetCustomAttribute<AuthorizeDefinitionAttribute>();
                    if (authorizeAttr == null) continue;

                    // Determine the HTTP method, default to GET if none is specified
                    string? authorizeAttrMethod = action?.GetCustomAttribute<HttpMethodAttribute>().HttpMethods.FirstOrDefault() ?? HttpMethods.Get;

                    // Create the action DTO
                    var actionDTO = new Application.DTOs.Configuration.Action()
                        {
                            ActionType = authorizeAttr.ActionType.ToString(),
                            Definition = authorizeAttr.Definition,
                            HttpType = authorizeAttrMethod,
                            Code = $"{authorizeAttrMethod}.{authorizeAttr.ActionType.ToString()}.{authorizeAttr.Definition.Replace(" ", "")}"
                        };

                    //var menu = menus.FirstOrDefault(m => m.Name == authorizeAttr.Menu);

                    menu.Name = authorizeAttr.Menu;
                    menu.Actions.Add(actionDTO);
                }

                if (menu.Name != null && menu.Actions.Any())
                {
                    menus.Add(menu);
                }
            }
            
            return menus;
        }
    }
}