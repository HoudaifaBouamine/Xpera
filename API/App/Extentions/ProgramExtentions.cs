using App.API.Extentions.DtosExtentions;
using App.API.Migrations;
using AutoMapper;

namespace App.API.Extentions
{
    public static class ProgramExtentions
    {
        public static void UseConfigration(this WebApplication app)
        {
            IMapper mapper = app.Services.GetService<IMapper>()!;
            UserExtentions.Configure(mapper);
            PostExtentions.Configure(mapper);
        }
    }
}
