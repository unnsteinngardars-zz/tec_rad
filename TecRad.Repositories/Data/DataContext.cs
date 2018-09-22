using System;
using System.Collections.Generic;
using TecRad.Models.Author;
using TecRad.Models.Category;
using TecRad.Models.NewsItem;

namespace TecRad.Repositories.Data
{
	public static class DataContext
	{
		public static List<NewsItem> _newsItems = new List<NewsItem>
		{
			new NewsItem
			{
				Id = 1,
				Title = "Trump wears a mankini",
				ShortDescription = "Donald Trump spotted in a local swimming pool in a green Borat mankini",
				LongDescription = "The world is shocked after a photo of American president Donald Trump wearing a green borat mankini in a local swimming pool in Reykjavik, Trump supporters are outraged and say that such homosexuality cannot be tolerated",
				PublishDate = DateTime.Now,
				ModifiedBy = "Davíð Oddsson",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now,
				AuthorId = 1,
				CategoryId = 3
			},
			new NewsItem
			{
				Id = 2,
				Title = "Pípulagningafeðgar sekir um skattalagabrot",
				ShortDescription = "Héraðsdómur Reykjaness hefur dæmt feðga, sem saman ráku pípulagningafyrirtæki, í fangelsi og greiðslu samtals 30 milljóna króna sektar fyrir skattalagabrot.",
				LongDescription = "Héraðsdómur Reykjaness hefur dæmt feðga, sem saman ráku pípulagningafyrirtæki, í fangelsi og greiðslu samtals 30 milljóna króna sektar fyrir skattalagabrot. Faðirinn var dæmdur í átta mánaða fangelsi en sonurinn fjögurra mánaða",
				PublishDate = DateTime.Now,
				ModifiedBy = "Ásdís Erna Guðmundsdóttir",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now,
				AuthorId = 2,
				CategoryId = 2
			},
			new NewsItem
			{
				Id = 3,
				Title = "Jóhanna Guðrún og Davíð gengu í hjónaband við hátíðlega athöfn í Garðakirkju",
				ShortDescription = "Tónlistarfólkið Jóhanna Guðrún Jónsdóttir og Davíð Sigurgeirsson lét pússa sig saman í Garðakirkju í Garðabæ í dag.",
				LongDescription = "Tónlistarfólkið Jóhanna Guðrún Jónsdóttir og Davíð Sigurgeirsson lét pússa sig saman í Garðakirkju í Garðabæ í dag. Jóhanna Guðrún er landsfræg fyrir sönghæfileika sína og en hún hefur starfað á því sviði frá barnsaldri.",
				PublishDate = DateTime.Now,
				ModifiedBy = "Unnsteinn Garðarsson",
				AuthorId = 1,
				CategoryId = 2

			},
			new NewsItem
			{
				Id = 4,
				Title = "Klopp vill að Liverpool verði „ljótasta“ liðið",
				ShortDescription = "Jurgen Klopp vill að Liverpool verði „ljótasta“ liðið í ensku úrvalsdeildinni.",
				LongDescription = "Jurgen Klopp vill að Liverpool verði „ljótasta“ liðið í ensku úrvalsdeildinni."
								+ "Liverpool hefur spilað fótbolta sem þykir mjög skemmtilegur á að horfa undir stjórn Þjóðverjans. Með Roberto Firmino, Mohamed Salah og Sadio Mane í framlínunni er liðið með mikið og ógnandi sóknarafl.",
				PublishDate = DateTime.Now,
				ModifiedBy = "Ásdís Erna Guðmundsdóttir",
				AuthorId = 2,
				CategoryId = 5
			},
			new NewsItem
			{
				Id = 5,
				Title = "Siggi Jóns gerði Skagastrákana að Íslandsmeisturum",
				ShortDescription = "Skagamenn eru komnir upp í Pepsideild karla í fótbolta á nýjan leik",
				LongDescription = "Skagamenn eru komnir upp í Pepsideild karla í fótbolta á nýjan leik og þeir ættu að hafa nóg af ungum og flottum strákum þar sem að 2. flokkur félagsins tryggði sér Íslandsmeistaratitilinn í gær.",
				PublishDate = DateTime.Now,
				ModifiedBy = "Unnsteinn Garðarsson",
				AuthorId = 1,
				CategoryId = 7
			}

		};

		public static List<Category> _categories = new List<Category>
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
				ModifiedBy = "Unnsteinn Garðarsson",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			},
			new Category
			{
				Id = 4,
				Name = "Veður",
				Slug = "veður",
				ParentCategoryId = 1,
				ModifiedBy = "Unnsteinn Garðarsson",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			},
			new Category
			{
				Id = 5,
				Name = "Íþróttir",
				Slug = "íþróttir",
				ParentCategoryId = 1,
				ModifiedBy = "Unnsteinn Garðarsson",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			},
			new Category
			{
				Id = 6,
				Name = "Enski Boltinn",
				Slug = "enski-boltinn",
				ParentCategoryId = 5,
				ModifiedBy = "Unnsteinn Garðarsson",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			},
			new Category
			{
				Id = 7,
				Name = "Íslenski boltinn",
				Slug = "íslenski-boltinn",
				ParentCategoryId = 5,
				ModifiedBy = "Unnsteinn Garðarsson",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			},
			new Category
			{
				Id = 8,
				Name = "Frjálsar Íþróttir",
				Slug = "frjálsar-íþróttir",
				ParentCategoryId = 5,
				ModifiedBy = "Unnsteinn Garðarsson",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			}
		};

		public static List<Author> _authors = new List<Author>
		{
			new Author
			{
				Id = 1,
				Name = "Unnsteinn Garðarsson",
				ProfileImgSource = "https://overland.org.au/wp-content/cat-on-typewriter.jpg",
				Bio = "Unnsteinn is white cat with a black back, he is a very ambitious writer and his favorite tool is an old fashioned typewriter",
				ModifiedBy = "Admin",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now,
			},
			new Author
			{
				Id = 2,
				Name = "Ásdís Erna Guðmundsdóttir",
				ProfileImgSource = "https://i.imgur.com/e0u37lt.jpg",
				Bio = "Better known as the most serious cat in the world, she is very serious about her work as a private investigative journalist",
				ModifiedBy = "Admin",
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			}
		};

	}
}