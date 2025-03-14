Console.WriteLine("How many chocolate eggs were gathered today?");

int eggCount = Convert.ToInt32(Console.ReadLine());
// Or if you'd prefer...
// string eggCountText = Console.ReadLine();
// int eggCount = Convert.ToInt32(eggCountText);

int forSisters = eggCount / 4;
int forDuckbear = eggCount % 4;

Console.WriteLine("Each sister gets " + forSisters + ".");
Console.WriteLine("The duckbear gets " + forDuckbear + ".");

// Answer this question: What are three total egg counts where the duckbear gets more than each sister does?
// Use the program you created to help you find the answer.
//
// If there is less than four eggs, the sisters will get 0. So a total count of 1, 2, or 3 would each
// give the duckbear more than the sisters. But 6 will give each sister 1 and the duckbear 2, 7 gives
// each sister 1 and the duckbear 3, and 11 gives each sister 2 and the duckbear 3.