namespace bug_tracker
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bug, GetBugDto>().ReverseMap();
            CreateMap<AddBugDto, Bug>().ReverseMap();
        }

    }
}
