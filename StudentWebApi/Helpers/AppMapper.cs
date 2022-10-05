using AutoMapper;
using StudentWebApi.Data;
using StudentWebApi.Models;

namespace StudentWebApi.Helpers
{
    public class AppMapper: Profile
    {
        public AppMapper()
        {
            CreateMap<Student, StudentModel>().ReverseMap();
        }
    }
}
