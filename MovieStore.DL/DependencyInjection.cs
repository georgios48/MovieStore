using Microsoft.Extensions.DependencyInjection;
using MovieStore.DL.Interfaces;
using MovieStore.DL.Repositories;
using MovieStore.DL.Repositories.MongoRepositories;

namespace MovieStore.DL
{
    public static class DependencyInjection
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IMovieRepository, MovieMongoRepository>();
            services.AddSingleton<IActorRepository, ActorStaticRepository>();
        }
    }
}
