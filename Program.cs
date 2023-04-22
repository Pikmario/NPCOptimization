using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCOptimization
{
	internal class Program
	{
		static Random random = new Random();

		static void Main(string[] args)
		{
			Dictionary<string, Dictionary<string, List<string>>> preferences = new Dictionary<string, Dictionary<string, List<string>>>
			{
				{ "Guide", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {} },
						{ "Likes", new List<string> {"Forest", "Clothier", "Zoologist"} },
						{ "Dislikes", new List<string> {"Ocean", "Steampunker"} },
						{ "Hates", new List<string> {"Painter"} }
					}
				},
				{ "Merchant", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {} },
						{ "Likes", new List<string> {"Forest", "Golfer", "Nurse"} },
						{ "Dislikes", new List<string> {"Desert", "Tax Collector"} },
						{ "Hates", new List<string> {"Angler"} }
					}
				},
				{ "Golfer", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Angler"} },
						{ "Likes", new List<string> {"Forest", "Painter", "Zoologist"} },
						{ "Dislikes", new List<string> {"Underground", "Pirate"} },
						{ "Hates", new List<string> {"Merchant"} }
					}
				},
				{ "Zoologist", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Witch Doctor"} },
						{ "Likes", new List<string> {"Forest", "Golfer"} },
						{ "Dislikes", new List<string> {"Desert", "Angler"} },
						{ "Hates", new List<string> {"Arms Dealer"} }
					}
				},
				{ "Tax Collector", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Merchant"} },
						{ "Likes", new List<string> {"Snow", "Party Girl"} },
						{ "Dislikes", new List<string> {"Hallow", "Demolitionist", "Mechanic"} },
						{ "Hates", new List<string> {} }
					}
				},
				{ "Mechanic", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Goblin Tinkerer"} },
						{ "Likes", new List<string> {"Snow", "Cyborg"} },
						{ "Dislikes", new List<string> {"Underground", "Arms Dealer"} },
						{ "Hates", new List<string> {"Clothier"} }
					}
				},
				{ "Cyborg", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {} },
						{ "Likes", new List<string> {"Snow", "Stylist", "Pirate", "Steampunker"} },
						{ "Dislikes", new List<string> {"Jungle", "Zoologist"} },
						{ "Hates", new List<string> {"Wizard"} }
					}
				},
				{ "Dye Trader", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {} },
						{ "Likes", new List<string> {"Desert", "Arms Dealer", "Painter"} },
						{ "Dislikes", new List<string> {"Forest", "Steampunker"} },
						{ "Hates", new List<string> {"Pirate"} }
					}
				},
				{ "Arms Dealer", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Nurse"} },
						{ "Likes", new List<string> {"Desert", "Steampunker"} },
						{ "Dislikes", new List<string> {"Snow", "Golfer"} },
						{ "Hates", new List<string> {"Demolitionist"} }
					}
				},
				{ "Steampunker", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Cyborg"} },
						{ "Likes", new List<string> {"Desert", "Painter"} },
						{ "Dislikes", new List<string> {"Jungle", "Party Girl", "Wizard", "Dryad"} },
						{ "Hates", new List<string> {} }
					}
				},
				{ "Dryad", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {} },
						{ "Likes", new List<string> {"Jungle", "Witch Doctor", "Truffle"} },
						{ "Dislikes", new List<string> {"Desert", "Angler"} },
						{ "Hates", new List<string> {"Golfer"} }
					}
				},
				{ "Witch Doctor", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {} },
						{ "Likes", new List<string> {"Jungle", "Dryad", "Guide"} },
						{ "Dislikes", new List<string> {"Hallow", "Nurse"} },
						{ "Hates", new List<string> {"Truffle"} }
					}
				},
				{ "Painter", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Dryad"} },
						{ "Likes", new List<string> {"Jungle", "Party Girl"} },
						{ "Dislikes", new List<string> {"Forest", "Cyborg", "Truffle"} },
						{ "Hates", new List<string> {} }
					}
				},
				{ "Angler", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {} },
						{ "Likes", new List<string> {"Ocean", "Party Girl", "Demolitionist", "Tax Collector"} },
						{ "Dislikes", new List<string> {"Desert"} },
						{ "Hates", new List<string> {"Tavernkeep"} }
					}
				},
				{ "Pirate", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Angler"} },
						{ "Likes", new List<string> {"Ocean", "Tavernkeep"} },
						{ "Dislikes", new List<string> {"Underground", "Stylist"} },
						{ "Hates", new List<string> {"Guide"} }
					}
				},
				{ "Stylist", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Dye Trader"} },
						{ "Likes", new List<string> {"Ocean", "Pirate"} },
						{ "Dislikes", new List<string> {"Snow", "Tavernkeep"} },
						{ "Hates", new List<string> {"Goblin Tinkerer"} }
					}
				},
				{ "Demolitionist", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Tavernkeep"} },
						{ "Likes", new List<string> {"Underground", "Mechanic"} },
						{ "Dislikes", new List<string> {"Ocean", "Goblin Tinkerer", "Arms Dealer"} },
						{ "Hates", new List<string> {} }
					}
				},
				{ "Goblin Tinkerer", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Mechanic"} },
						{ "Likes", new List<string> {"Underground", "Dye Trader"} },
						{ "Dislikes", new List<string> {"Jungle", "Clothier"} },
						{ "Hates", new List<string> {"Stylist"} }
					}
				},
				{ "Clothier", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Truffle"} },
						{ "Likes", new List<string> {"Caverns", "Tax Collector"} },
						{ "Dislikes", new List<string> {"Hallow", "Nurse"} },
						{ "Hates", new List<string> {"Mechanic"} }
					}
				},
				{ "Wizard", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Golfer"} },
						{ "Likes", new List<string> {"Hallow", "Merchant"} },
						{ "Dislikes", new List<string> {"Ocean", "Witch Doctor"} },
						{ "Hates", new List<string> {"Cyborg"} }
					}
				},
				{ "Nurse", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Arms Dealer"} },
						{ "Likes", new List<string> {"Hallow", "Wizard"} },
						{ "Dislikes", new List<string> {"Snow", "Party Girl", "Dryad"} },
						{ "Hates", new List<string> {"Zoologist"} }
					}
				},
				{ "Party Girl", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Wizard", "Zoologist"} },
						{ "Likes", new List<string> {"Hallow", "Stylist"} },
						{ "Dislikes", new List<string> {"Underground", "Merchant"} },
						{ "Hates", new List<string> {"Tax Collector"} }
					}
				},
				{ "Tavernkeep", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Demolitionist"} },
						{ "Likes", new List<string> {"Hallow", "Gobling Tinkerer"} },
						{ "Dislikes", new List<string> {"Snow", "Guide"} },
						{ "Hates", new List<string> {"Dye Trader"} }
					}
				},
				{ "Truffle", new Dictionary<string, List<string>> {
						{ "Loves", new List<string> {"Guide"} },
						{ "Likes", new List<string> {"Mushroom", "Dryad"} },
						{ "Dislikes", new List<string> {"Clothier"} },
						{ "Hates", new List<string> {"Witch Doctor"} }
					}
				},
			};

			Dictionary<string, double> happiness_fitness_multipiers = new Dictionary<string, double>
			{
				{ "Goblin Tinkerer", 10 },
				{ "Mechanic", 5 },
				{ "Guide", 0 },
				{ "Tax Collector", 5 }
			};

			Dictionary<string, List<string>> princess = new Dictionary<string, List<string>> {
				{ "Loves", new List<string> {} },
				{ "Likes", new List<string> {} },
				{ "Dislikes", new List<string> {} },
				{ "Hates", new List<string> {} }
			};

			foreach (var npc in preferences)
			{
				string npc_name = npc.Key;
				princess["Loves"].Add(npc_name);
				preferences[npc_name]["Likes"].Add("Princess");
			}
			preferences["Princess"] = princess;

			int population_size = 500;
			int new_generation_size = population_size / 10;
			int generations = 1000000;

			List<npc_setup> population = new List<npc_setup>();
			List<npc_setup> new_generation = new List<npc_setup>();

			for (int i = 0; i < population_size; i++)
			{
				population.Add(new npc_setup());
			}

			for (int generation = 1; generation <= generations; generation++)
			{
				foreach (npc_setup setup in population)
				{
					calculate_fitness(setup);
				}

				population.Sort(delegate (npc_setup a, npc_setup b) { return b.fitness.CompareTo(a.fitness); });

				double top_fitness = population[0].fitness;
				double bottom_fitness = population.Last().fitness;

				string output = "Generation: " + generation + " top fitness: " + top_fitness + "\r\n";
				foreach (npc_arrangement arrangement in population[0].list_of_arrangements)
				{
					if (arrangement.npcs.Count == 0)
					{
						continue;
					}
					string line = arrangement.biome + ": ";
					foreach (string npc in arrangement.npcs)
					{
						line += npc + " (" + arrangement.happiness[npc] + "), ";
					}
					output += line.Trim(' ').Trim(',') + "\r\n";
				}
				output += "Towns: " + population[0].town_count + "\r\n";
				output += "Pylons: " + population[0].pylon_amount + " (" + string.Join(", ", population[0].pylons) + ")\r\n";

				double spread = 0 - bottom_fitness;

				Console.Clear();
				Console.WriteLine(output);

				new_generation = new List<npc_setup>();
				while (new_generation.Count() < new_generation_size)
				{
					foreach (npc_setup npc_setup in population)
					{
						double child_chance;
						if (top_fitness == bottom_fitness)
						{
							child_chance = 1;
						}
						else
						{
							child_chance = (npc_setup.fitness + spread) / (top_fitness + spread);
						}

						double rand = random.NextDouble();
						if (rand < child_chance)
						{
							new_generation.Add(npc_setup);
						}

						if (new_generation.Count() > new_generation_size)
						{
							break;
						}
					}
				}

				population.Clear();
				population = new_generation.ToList();

				do
				{
					foreach (npc_setup npc_setup in new_generation)
					{
						npc_setup new_setup = new npc_setup(npc_setup);
						new_setup.mutate();
						population.Add(new_setup);
					}
				} while (population.Count() < population_size);
			}

			population[0].get_highest_pylon_combo_count();

			Console.Read();

			double calculate_fitness(npc_setup npc_setup)
			{
				double fitness = 0;
				Dictionary<string, double> npc_happiness = new Dictionary<string, double>();
				foreach (var arrangement in npc_setup.list_of_arrangements)
				{
					foreach (var npc in arrangement.npcs)
					{
						double happiness = calculate_happiness(npc, arrangement);

						double happiness_fitness = (1 - happiness) * 100;
						if (happiness_fitness_multipiers.ContainsKey(npc))
						{
							happiness_fitness *= happiness_fitness_multipiers[npc];
						}
						fitness += happiness_fitness;

						npc_happiness[npc] = happiness;
					}
				}

				//int pylon_amount = npc_setup.get_purchasable_pylons().Count;
				int pylon_amount = npc_setup.get_highest_pylon_combo_count();

				fitness += pylon_amount * 10;

				int diff = npc_setup.count_towns() - pylon_amount;
				fitness -= Math.Abs(diff) * 25;

				if (npc_setup.town_count == pylon_amount)
				{
					fitness += 25;
				}

				npc_setup.fitness = fitness;
				npc_setup.pylon_amount = pylon_amount;

				return fitness;
			}

			double calculate_happiness(string npc, npc_arrangement arrangement)
			{
				double happiness = 1;

				Dictionary<string, double> happiness_types = new Dictionary<string, double>
				{
					{ "Loves", .88 },
					{ "Likes", .94 },
					{ "Dislikes", 1.06 },
					{ "Hates", 1.12 },
				};

				List<string> biome_split = arrangement.biome.Split(' ').ToList();

				bool biome_calculated = false;
				foreach (var happiness_type in happiness_types)
				{
					if (!biome_calculated)
					{
						if (happiness_type.Value < 1)
						{
							//if any biome in the hybrid biome is liked, use that biome
							if (biome_split.Intersect(preferences[npc][happiness_type.Key]).Count() > 0)
							{
								happiness *= happiness_type.Value;
								biome_calculated = true;
							}
						}
						else
						{
							//if no biomes in the hybrid biome are liked, use the first
							if (preferences[npc][happiness_type.Key].Contains(biome_split[0]))
							{
								happiness *= happiness_type.Value;
								biome_calculated = true;
							}
						}
					}

					foreach (string neighbor in arrangement.npcs)
					{
						if (neighbor == npc)
						{
							continue;
						}

						if (preferences[npc][happiness_type.Key].Contains(neighbor))
						{
							happiness *= happiness_type.Value;
						}
					}
				}

				if (npc == "Princess")
				{
					if (arrangement.npcs.Count <= 3)
					{
						happiness = 10;
					}
				}
				else
				{
					if (arrangement.npcs.Count <= 3)
					{
						happiness *= .95;
					}
					else if (arrangement.npcs.Count > 3)
					{
						happiness *= 1.05 * (arrangement.npcs.Count - 3);
					}
				}

				happiness = Math.Round(Math.Min(1.5, Math.Max(.75, happiness)), 2);

				arrangement.happiness[npc] = happiness;

				return happiness;
			}
		}
	}

	class npc_arrangement
	{
		public string biome;
		public List<string> npcs = new List<string>();
		public Dictionary<string, double> happiness = new Dictionary<string, double>();

		public npc_arrangement(string biome)
		{
			this.biome = biome;
		}

		public npc_arrangement(npc_arrangement clone)
		{
			this.biome = clone.biome;
			this.npcs = clone.npcs.ToList();
			this.happiness = new Dictionary<string, double>();
		}

		public bool can_buy_pylon()
		{
			if (npcs.Count < 2)
			{
				//can't but pylon if there's only one NPC
				return false;
			}
			foreach (var npc in npcs)
			{
				if (npc == "Guide" || npc == "Nurse" || npc == "Tax Collector" || npc == "Angler")
				{
					//can't buy pylon from this npc, keep checking
					continue;
				}
				if (this.happiness[npc] <= .9)
				{
					return true;
				}
			}
			return false;
		}
	}

	class npc_setup
	{
		public List<npc_arrangement> list_of_arrangements = new List<npc_arrangement>();
		public double fitness;
		public double pylon_amount;
		public int town_count;
		public List<string> pylons = new List<string>();
		static Random random = new Random();

		List<string> npcs = new List<string>
		{
			"Guide",
			"Merchant",
			"Nurse",
			"Painter",
			"Golfer",
			"Dye Trader",
			"Demolitionist",
			"Dryad",
			"Tavernkeep",
			"Arms Dealer",
			"Party Girl",
			"Stylist",
			"Angler",
			"Goblin Tinkerer",
			"Witch Doctor",
			"Clothier",
			"Mechanic",
			"Pirate",
			"Truffle",
			"Wizard",
			"Tax Collector",
			"Steampunker",
			"Cyborg",
			"Zoologist",
			"Princess"
		};

		public npc_setup()
		{
			List<string> biomes = biome_list.biomes;

			foreach (string biome in biomes)
			{
				list_of_arrangements.Add(new npc_arrangement(biome));
			}

			foreach (string npc in npcs)
			{
				if (npc == "Truffle")
				{
					add_npc_to_biome(npc, "Mushroom");
				}
				else if (npc == "Mechanic" || npc == "Goblin Tinkerer")
				{
					add_npc_to_biome(npc, "Snow Underground");
				}
				else if (npc == "Witch Doctor")
				{
					add_npc_to_biome(npc, "Jungle Underground");
				}
				else
				{
					int r = random.Next(list_of_arrangements.Count());
					list_of_arrangements[r].npcs.Add(npc);
				}
			}
		}

		public npc_setup(npc_setup clone)
		{
			foreach (npc_arrangement npc_arrangement in clone.list_of_arrangements)
			{
				this.list_of_arrangements.Add(new npc_arrangement(npc_arrangement));
			}
		}

		public void add_npc_to_biome(string npc, string biome)
		{
			foreach (npc_arrangement arrangement in list_of_arrangements)
			{
				if (arrangement.biome == biome)
				{
					arrangement.npcs.Add(npc);
					break;
				}
			}
		}

		public void mutate()
		{
			int mutations = random.Next(1, 10);

			for (int i = 0; i < mutations; i++)
			{
				int biome_from = random.Next(this.list_of_arrangements.Count());
				int biome_to = random.Next(this.list_of_arrangements.Count());

				npc_arrangement arrangement_from = this.list_of_arrangements[biome_from];

				if (arrangement_from.npcs.Count == 0)
				{
					i--;
					continue;
				}

				int npc_to_move_id = random.Next(arrangement_from.npcs.Count());
				string npc_to_move = arrangement_from.npcs[npc_to_move_id];

				if (npc_to_move == "Truffle" || npc_to_move == "Witch Doctor")
				{
					i--;
					continue;
				}

				//Console.WriteLine("Moving " + npc_to_move + " from " + list_of_arrangements[biome_from].biome + " to " + list_of_arrangements[biome_to].biome);
				this.list_of_arrangements[biome_from].npcs.Remove(npc_to_move);
				this.list_of_arrangements[biome_to].npcs.Add(npc_to_move);
			}
		}

		public int count_towns()
		{
			int count = 0;
			foreach (npc_arrangement arrangement in list_of_arrangements)
			{
				if (arrangement.npcs.Count > 0)
				{
					count++;
				}
			}
			this.town_count = count;
			return count;
		}

		public int get_usable_pylon_amount()
		{
			List<string> purchasable_pylons = this.get_purchasable_pylons();

			return purchasable_pylons.Count();
		}

		public List<string> get_purchasable_pylons()
		{
			List<string> purchasable_pylons = new List<string>();

			foreach (var arrangement in this.list_of_arrangements)
			{
				if (arrangement.can_buy_pylon())
				{
					//pylon is available for sale, figure out which ones
					//if single biome, it's that one
					//if hybrid biome, every biome that isn't underground
					List<string> biome_split = arrangement.biome.Split(' ').ToList();
					if (biome_split.Count > 1 && biome_split.Contains("Underground"))
					{
						biome_split.Remove("Underground");
					}
					purchasable_pylons.AddRange(biome_split);
				}
			}

			purchasable_pylons = purchasable_pylons.Distinct().ToList();

			this.pylons = purchasable_pylons.ToList();

			return purchasable_pylons;
		}

		public int get_highest_pylon_combo_count()
		{
			List<string> purchasable_pylons = this.get_purchasable_pylons();
			List<string> biomes = new List<string>();

			foreach (npc_arrangement arrangement in this.list_of_arrangements)
			{
				if (arrangement.npcs.Count > 0)
				{
					biomes.Add(arrangement.biome);
				}
			}

			combo_calls = 0;
			int highest_combo = this.get_highest_pylon_combo_count(purchasable_pylons, biomes);
			/*Console.WriteLine("pylons: " + string.Join(", ", purchasable_pylons));
			Console.WriteLine("biomes: " + string.Join(", ", biomes));
			Console.WriteLine("combos: " + combo_calls);
			Console.WriteLine();*/
			return highest_combo;
		}

		int combo_calls;
		public int get_highest_pylon_combo_count(List<string> purchasable_pylons, List<string> biomes)
		{
			combo_calls++;
			int highest_pylon_combo = 0;

			if (purchasable_pylons.Count == 0 || biomes.Count == 0)
			{
				return 0;
			}

			List<string> valid_biomes;
			Dictionary<string, int> pylon_valid_biome_counts = new Dictionary<string, int>();
			foreach (string purchasable_pylon in purchasable_pylons)
			{
				valid_biomes = this.get_valid_biomes(purchasable_pylon, biomes);
				
				pylon_valid_biome_counts[purchasable_pylon] = valid_biomes.Count;
			}

			var sorted_pylon_valid_biome_counts = pylon_valid_biome_counts.OrderBy(pair => pair.Value).Take(pylon_valid_biome_counts.Count).ToDictionary(pair => pair.Key, pair => pair.Value); ;

			var first_pylon = sorted_pylon_valid_biome_counts.First();
			
			string pylon = first_pylon.Key;

			valid_biomes = this.get_valid_biomes(pylon, biomes);

			int sub_count = 0;
			foreach (string biome in valid_biomes)
			{
				List<string> new_pylons = purchasable_pylons.ToList();
				new_pylons.Remove(pylon);

				List<string> new_biomes = biomes.ToList();
				new_biomes.Remove(biome);

				sub_count = Math.Max(sub_count, get_highest_pylon_combo_count(new_pylons, new_biomes));
			}

			sub_count++;
			highest_pylon_combo = Math.Max(sub_count, highest_pylon_combo);

			return highest_pylon_combo;
		}
		public List<string> get_valid_biomes(string pylon, List<string> biomes)
		{
			List<string> valid_biomes = new List<string>();

			valid_biomes = new List<string>();
			foreach (string biome in biomes)
			{
				List<string> biome_split = biome.Split(' ').ToList();
				if (pylon == "Underground" && biome_split.Count() > 1)
				{
					//don't use underground pylon in a hybrid biome, can't buy it there anyway.
					continue;
				}

				if (biome.Contains(pylon))
				{
					valid_biomes.Add(biome);
				}
			}

			return valid_biomes;
		}
	}

	public static class biome_list
	{
		public static List<string> biomes = new List<string>
		{
			"Mushroom",
			"Hallow",
			"Hallow Snow",
			"Hallow Desert",
			"Hallow Snow Underground",
			"Hallow Desert Underground",
			"Hallow Ocean",
			"Hallow Underground",
			"Jungle Underground",
			"Snow",
			"Snow Underground",
			"Ocean",
			"Desert",
			"Desert Underground",
			"Underground",
			"Forest",
		};
	}
}
