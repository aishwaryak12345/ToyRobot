using ToyRobot;

namespace ToyRobot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0 && File.Exists(args[0]) && Path.GetExtension(args[0]) == ".txt")
            {
                RunRobotSimulation(args);
            }
            else
            {
                CreateHostBuilder(args).Build().Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void RunRobotSimulation(string[] args)
        {
            var input = args.Where(File.Exists);
            foreach (var itempath in input)
            {
                Console.WriteLine("Executing the commands" + itempath);
                RunCommands(itempath);

                Console.WriteLine("**************");
            }
            Console.ReadLine();
        }

        public static void RunCommands(string itempath)
        {
            var robot = new Robot();
            var simulator = new Simulator(robot);

            using (var givenfile = new StreamReader(itempath))
            {
                string Commands;
                while ((Commands = givenfile.ReadLine()) != null)
                {
                    Console.WriteLine("Executing the given commands" + Commands);
                    simulator.ExecuteCommand(Commands);
                }
            }
        }
    }

    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}