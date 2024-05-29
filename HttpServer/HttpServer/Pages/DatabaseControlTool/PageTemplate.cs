using Common;
using HttpServer.Shared.Enum;
using MatBlazor;
using MySqlConnector;

namespace HttpServer.Pages.DatabaseControlTool;

public partial class PageTemplate
{
#pragma warning disable 1998
#pragma warning disable 0169
#pragma warning disable 0414   
    
    private int tabIndex = 0;
    private Player player = null;
    private List<HttpServer.Pages.DatabaseControlTool.PageTemplate.ExampleClass> list = new List<HttpServer.Pages.DatabaseControlTool.PageTemplate.ExampleClass>();
    
    bool dialogIsOpen = false;

    public async Task OnPlayerChanged(Player player)
    {
        this.player = player;
        
        if (player != null)
        {
            
        }
    }
    
    private void OpenDialog()
    {
        dialogIsOpen = true;
    }
    
    private void CloseDialog()
    {
        dialogIsOpen = false;
    }
    
    private void Toggle(bool toggled)
    {
        if (toggled)
        {
            // set bool value to true
        }
        else
        {
            // set bool value to false
        }
    }
}