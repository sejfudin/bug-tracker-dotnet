namespace bug_tracker
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bug, GetBugDto>();
            CreateMap<AddBugDto, Bug>();
        }

    }
}
