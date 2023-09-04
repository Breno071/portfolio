using System.Net.Http.Json;

using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Components
{
    public partial class About
    {
        [Parameter, EditorRequired]
        public required HttpClient Http { get; set; }

        [Parameter, EditorRequired]
        public required HeroImageService HeroImageService { get; set; }

        private AboutMe? _aboutMe;
        private HeroImage? _hero;

        protected override async Task OnInitializedAsync()
        {
            _aboutMe = await Http.GetFromJsonAsync<AboutMe>("sample-data/aboutme.json");
            _hero = await HeroImageService.GetHeroAsync(img => img.Name is "about");
        }
    }
}
