using System;
using System.Collections.Generic;
using TecRad.Models.Category;
using TecRad.Models.NewsItem;

namespace TecRad.Repositories.Data
{
	public static class DataContext
	{
		private static List<NewsItem> _newsItems = new List<NewsItem>
		{
			new NewsItem
			{
				Id = 1,
				Title = "Trump wears a mankini",
				ShortDescription = "Donald Trump spotted in a local swimming pool in a green Borat mankini",
				LongDescription = "The world is shocked after a photo of American president Donald Trump wearing a "
								+ "green borat mankini in a local swimming pool in Reykjavik, Trump supporters are "
								+ "outraged and say that such homosexuality cannot be tolerated",
				PublishDate = DateTime.Now,
				ModifiedBy = "Davíð Oddsson",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			},
			new NewsItem
			{
				Id = 2,
				Title = "Pípulagningafeðgar sekir um skattalagabrot",
				ShortDescription = "Héraðsdómur Reykjaness hefur dæmt feðga, sem saman ráku pípulagningafyrirtæki, í fangelsi og greiðslu samtals 30 milljóna króna sektar fyrir skattalagabrot.",
				LongDescription = "Héraðsdómur Reykjaness hefur dæmt feðga, sem saman ráku pípulagningafyrirtæki, í fangelsi og greiðslu samtals 30 milljóna króna sektar fyrir skattalagabrot."
								+ "Faðirinn var dæmdur í átta mánaða fangelsi en sonurinn fjögurra mánaða, en fullnusta refsinga fellur niður að tveimur árum liðnum, haldi þeir almennt skilorð."
								+ "Feðgarnir voru fundnir sekir  um að hafa ekki staðið ríkissjóði skil á virðisaukaskatti og staðgreiðslu vegna launa starfsmanna á árunum 2014 til 2016."
								+ "Þeir neituðu báðir sök en dómurinn mat það svo að samkvæmt framburði feðganna hafi þeir báðir borið ábyrgð á rekstri fyrirtækisins. Sonurinn taldi þó að hann hafi verið notaður sem „leppur“ og að faðir hans hafi séð um að stýra fjármálum fyrirtækisins.",
				PublishDate = DateTime.Now,
				ModifiedBy = "Ásdís Erna Guðmundsdóttir",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			},
			new NewsItem
			{
				Id = 3,
				Title = "Jóhanna Guðrún og Davíð gengu í hjónaband við hátíðlega athöfn í Garðakirkju",
				ShortDescription = "Tónlistarfólkið Jóhanna Guðrún Jónsdóttir og Davíð Sigurgeirsson lét pússa sig saman í Garðakirkju í Garðabæ í dag.",
				LongDescription = "Tónlistarfólkið Jóhanna Guðrún Jónsdóttir og Davíð Sigurgeirsson lét pússa sig saman í Garðakirkju í Garðabæ í dag."
								+ "Jóhanna Guðrún er landsfræg fyrir sönghæfileika sína og en hún hefur starfað á því sviði frá barnsaldri. Hún er hvað þekktust fyrir að hafa hafnað í öðru sæti í söngvakeppni evrópskra sjónvarpsstöðva, Eurovision, í Rússlandi árið 2009 þar sem hún flutti lagið Is it True?"
								+ "Davíð er einn af frambærilegustu gítarleikurum landsins en hann á ekki langt að sækja hæfileikana því faðir hans er gítargoðsögnin Sigurgeir Sigmundssoni sem hefur leikið með hljómsveitum á borð við Start, Gildrunni og Drýsli.",
				PublishDate = DateTime.Now,
				ModifiedBy = "Unnsteinn Garðarsson",

			}

		};

		private static List<Category> _categories = new List<Category>
		{
			new Category
			{
				Id = 1,
				Name = "Fréttir",
				Slug = "fréttir",
				ParentCategoryId = 0,
				ModifiedBy = "Unnsteinn Garðarsson",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			},
			new Category
			{
				Id = 2,
				Name = "Innlent",
				Slug = "innlent",
				ParentCategoryId = 1,
				ModifiedBy = "Unnsteinn Garðarsson",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			},
			new Category
			{
				Id = 3,
				Name = "Erlent",
				Slug = "erlent",
				ParentCategoryId = 1,
				ModifiedBy = "Unnsteinn Garðarsson"
			}
		};

	}
}