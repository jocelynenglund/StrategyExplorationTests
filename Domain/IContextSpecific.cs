using Domain.Models;

namespace Domain;

interface IContextSpecific
{
    bool AppliesToContext(Context context);
}
