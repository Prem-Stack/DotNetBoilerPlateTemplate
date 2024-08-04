/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Application.Handlers.Users.Mappers;

/// <summary>
/// Represents a mapper class for mapping User to UserDto.
/// </summary>
public class UserProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserProfile"/> class.
    /// </summary>
    public UserProfile()
    {
        // CreateMap<CountryModel, CountryDto>().ReverseMap();

        CreateMap<User, UserDto>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.FirstName));
    }
}
