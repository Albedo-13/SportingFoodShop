using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportingFoodShop.Models
{
    public class SportingFoodContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<AggregateType> AggregateTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }  // конечный список оформленных покупок

        public DbSet<Review> Reviews { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Place> Places { get; set; }
    }

    // Затычка (При удалении убрать вызов в Global.asax)
    public class SportingFoodInit : DropCreateDatabaseAlways<SportingFoodContext>
    {
        protected override void Seed(SportingFoodContext db)
        {
            Image i1 = new Image
            {
                Id = 1,
                ImageName = "1_100pr-whey-gold-900gr.webp",
                ImagePath = "~/Images/ProductImages/1_100pr-whey-gold-900gr.webp",
                ImageType = "image",
            };
            Image i2 = new Image
            {
                Id = 2,
                ImageName = "2-opti-women-60t.webp",
                ImagePath = "~/Images/ProductImages/2-opti-women-60t.webp",
                ImageType = "image",
            };
            Image i3 = new Image
            {
                Id = 3,
                ImageName = "3_100pr-plant-protein-900gr.webp",
                ImagePath = "~/Images/ProductImages/3_100pr-plant-protein-900gr.webp",
                ImageType = "image",
            };
            Image i4 = new Image
            {
                Id = 4,
                ImageName = "4-opti-men-150t.webp",
                ImagePath = "~/Images/ProductImages/4-opti-men-150t.webp",
                ImageType = "image",
            };
            Image i5 = new Image
            {
                Id = 5,
                ImageName = "5_animal-flex-44caps.webp",
                ImagePath = "~/Images/ProductImages/5_animal-flex-44caps.webp",
                ImageType = "image",
            };
            Image i6 = new Image
            {
                Id = 6,
                ImageName = "6_100pr-casein-900gr.webp",
                ImagePath = "~/Images/ProductImages/6_100pr-casein-900gr.webp",
                ImageType = "image",
            };
            Image i7 = new Image
            {
                Id = 7,
                ImageName = "7_amino-x-435gr.webp",
                ImagePath = "~/Images/ProductImages/7_amino-x-435gr.webp",
                ImageType = "image",
            };
            Image i8 = new Image
            {
                Id = 8,
                ImageName = "8_super-omega3-120caps.webp",
                ImagePath = "~/Images/ProductImages/8_super-omega3-120caps.webp",
                ImageType = "image",
            };
            Image i9 = new Image
            {
                Id = 9,
                ImageName = "9_gold-standart-gainer-2250gr.webp",
                ImagePath = "~/Images/ProductImages/9_gold-standart-gainer-2250gr.webp",
                ImageType = "image",
            };
            Image i10 = new Image
            {
                Id = 10,
                ImageName = "10_biotech-hyper-mass5000-4000gr.webp",
                ImagePath = "~/Images/ProductImages/10_biotech-hyper-mass5000-4000gr.webp",
                ImageType = "image",
            };
            Image i11 = new Image
            {
                Id = 11,
                ImageName = "11-pure_creatine_monohydrate-250gr.webp",
                ImagePath = "~/Images/ProductImages/11-pure_creatine_monohydrate-250gr.webp",
                ImageType = "image",
            };
            Image i12 = new Image
            {
                Id = 12,
                ImageName = "12-creatine_creatine-rule-one-375gr.webp",
                ImagePath = "~/Images/ProductImages/12-creatine_creatine-rule-one-375gr.webp",
                ImageType = "image",
            };

            Category c1 = new Category
            {
                Id = 1,
                Name = "Витамины/Минералы"
            };
            Category c2 = new Category
            {
                Id = 2,
                Name = "Протеин"
            };
            Category c3 = new Category
            {
                Id = 3,
                Name = "Для суставов/связок"
            };
            Category c4 = new Category
            {
                Id = 4,
                Name = "BCAA"
            };
            Category c5 = new Category
            {
                Id = 5,
                Name = "Гейнеры"
            };
            Category c6 = new Category
            {
                Id = 6,
                Name = "Креатин"
            };

            AggregateType at1 = new AggregateType
            {
                Id = 1,
                Name = "Порошок",
                Postfix = "гр."
            };
            AggregateType at2 = new AggregateType
            {
                Id = 2,
                Name = "Капсулы",
                Postfix = "капс."
            };
            AggregateType at3 = new AggregateType
            {
                Id = 3,
                Name = "Таблетки",
                Postfix = "табл."
            };

            Product p1 = new Product
            {
                Id = 1,
                Name = "100% WHEY Gold Standart",
                ShortDescription = "100% WHEY GOLD STANDARD от Optimum Nutrition С самого начала компания Optimum Nutrition подняла стандарты протеиновых добавок на небывалую высоту. Сейчас мы опять поднимаем планку вместе с 3-им поколением ON 100% Whey Protein – ON 100% Whey Gold Standart. Также как и его ...",
                FullDescription = "Миллионы покупателей довольны Optimum Nutrition 100% WHEY GOLD STANDARD, и они  не могут быть неправы! Еще на заре производства протеинов Optimum Nutrition установил стандарт, в соответствии с которым стали производиться все последующие ингредиенты сывороточного протеина.Теперь мы устанавливаем новый стандарт, с третьим поколением Optimum Nutrition 100 % WHEY GOLD STANDARD. Подобно предшественникам, ON 100 % WHEY GOLD STANDARD содержит в себе первоклассные оптимальные пищевые добавки.",
                Weight = 907,
                Cost = 79.90m,
                ImageId = 1,
                TypeId = 1,
                CategoryId = 2
            };
            Product p2 = new Product
            {
                Id = 2,
                Name = "OPTI - WOMEN",
                ShortDescription = "Opti-Women от Optimum Nutrition сочетает в себе витамины и незаменимые минералы, включая Osivone и соевые изофлавоны и многое другое для создания нашей 'все включено' формулы для женщин. Основное: - Состав подобран специально для женщин",
                FullDescription = "Opti-Women от Optimum Nutrition — это превосходный витаминно-минеральный комплекс, созданный специально для женщин. В нем максимально сбалансировано количество витаминов, минералов, антиоксидантов и травяных экстрактов. При употреблении Opti-Women улучшается мозговая активность, появляется больше энергии, повышается общий тонус. Витамины, минералы и другие необходимые питательные вещества являются основными строительными блоками нашего тела.Среди прочего, они повышают энергичность, иммунитет, производительность и общее состояние здоровья.Opti - Women был разработан как всеобъемлющая, оптимизированная система питательных веществ, дополненная антиоксидантами и растительными компонентами специально для женщин.В одной капсуле объединены более 40 активных ингредиентов.",
                Weight = 60,
                Cost = 42.00m,
                ImageId = 2,
                TypeId = 3,
                CategoryId = 1
            };
            Product p3 = new Product
            {
                Id = 3,
                Name = "100% PLANT PROTEIN",
                ShortDescription = "Гороховый изолят без лактозы и глютена. 100% Plant Protein - основан на одном из лучших, высоко чистом сырье: бельгийском Pisane® изоляте горохового белка, произведённом из локально выращенного желтого гороха. Это абсолютно естественный процесс и ...",
                FullDescription = "Гороховый белок, по скорости усвоения быстрее казеина, но медленнее сыворотки и изолята. Один самых богатых по составу, среди аналогов растительного белка. Имеет большое количество заменимых и незаменимых аминокислот, дополнительно ко всему, в гороховом протеин лидер по количеству аргинину на порцию. В составе присутствует гранатовый протеин, дело в том что составляющая белка в гранатах очень мала, около 1 грамм на 100 грам фруктов, но в гранатовом соке 15 аминокислот, что делает его просто необходимым продуктом для вегетарианцев. Белок на уровне с воздухом и водой, один из самых необходимых элементов для функционирования человека.Является незаменимым строительным материалом, участвует во всех процессах человеческого организма(участвует в гормональных процессах, обмене веществ, защитных и рецепторных реакциях – создавая новые здоровые молодые клетки)",
                Weight = 900,
                Cost = 62.50m,
                ImageId = 3,
                TypeId = 1,
                CategoryId = 2
            };
            Product p4 = new Product
            {
                Id = 4,
                Name = "OPTI - MEN",
                ShortDescription = "Opti-Men от Optimum Nutrition Opti-Men от Optimum Nutrition это удивительный комплекс, специально для мужчин, содержащий в составе витамины, минералы, антиоксиданты, ферменты. Эффективен как общеукрепляющее средство. Повышает иммунитет, а так же активизирует обмен веществ, ...",
                FullDescription = "Opti-Men от Optimum Nutrition это удивительный комплекс, специально для мужчин, содержащий в составе витамины, минералы, антиоксиданты, ферменты. Эффективен как общеукрепляющее средство. Повышает иммунитет, а так же активизирует обмен веществ, стимулирует физические, умственные, и сексуальные возможности мужчины. Отличный выбор мужчин. Фундаментальными строительными блоками человеческого тела являются витамины, минералы и другие незаменимые питательные вещества.Они обеспечивают прочную основу и отвечают за энергетический уровень в организме, нашу производительность и жизнеспособность.Opti - Men является торговой маркой мирового производителя Optimum Nutrition, представляющая собой полный комплекс питательных веществ, скомпонованный из 75 ключевых ингредиентов, объединенный в оптимально сбалансированную питательную систему.",
                Weight = 150,
                Cost = 99.00m,
                ImageId = 4,
                TypeId = 3,
                CategoryId = 1
            };
            Product p5 = new Product
            {
                Id = 5,
                Name = "ANIMAL FLEX",
                ShortDescription = "Animal Flex разработан, чтобы сделать Ваши суставы и связки более крепкими и чтобы защитить их от перегрузок во время тренировок. Каждый пакетик Animal Flex состоит из нескольких ключевых комплексов веществ, защищающих Ваши суставы: (1) мощный комплекс, помогающий восстановить ...",
                FullDescription = "Animal Flex разработан, чтобы сделать Ваши суставы и связки более крепкими и чтобы защитить их от перегрузок во время тренировок. Каждый пакетик Animal Flex состоит из нескольких ключевых комплексов веществ, защищающих Ваши суставы: (1) мощный комплекс, помогающий восстановить соединительную ткань; (2) комплекс веществ, улучшающих смазку суставов и смягчающих тем самым стресс от поднятия тяжестей на тренировке; (3) комплекс, способствующий восстановлению связок и снимающий воспаление; (4) витаминно-минеральная смесь, которая еще более способствует сохранению и поддержанию здоровья суставов и связок. Animal Flex — это полная и эффективная формула для достижения серьезного результата. Это Ваше надежное оружие в «железной» борьбе.",
                Weight = 44,
                Cost = 115.00m,
                ImageId = 5,
                TypeId = 2,
                CategoryId = 3
            };
            Product p6 = new Product
            {
                Id = 6,
                Name = "100% CASEIN ОТ LEVEL UP",
                ShortDescription = "Чистый мицеллярный казеин с минимум добавок.",
                FullDescription = "Чистый мицеллярный казеин с минимум добавок. Казеин усваивается медленнее большинства белков, что дает более продолжительную подпитку мышц аминокислотами. Такой белок отлично подходит для приема перед сном. Применение: Для получения готового продукта смешайте 2 мерные ложки без горки(35 г) продукта с 300 - 500 мл воды, молока или любого напитка на ваш выбор.",
                Weight = 900,
                Cost = 65.00m,
                ImageId = 6,
                TypeId = 1,
                CategoryId = 2
            };
            Product p7 = new Product
            {
                Id = 7,
                Name = "AMINO - X",
                ShortDescription = "AMINO X - первые шипучие BCAA, которые дают Вам выносливость и максимально быстрое восстановление.  AMINO X способствует: усилению синтеза белков (анаболизму)  улучшению ресинтеза гликогена  увеличению чувствительности к инсулину  анти-катаболизму...",
                FullDescription = "На протяжении многих лет компания BSN поставляет миру спортивного питания множество новых продуктов для строительства мышц. В стремлении принести результативные, интересные и инновационные продукты на рынок мы разработали новейшую добавку - прорыв в разделе аминокислот с разветвленной цепочкой. AMINO X - первые шипучие BCAA, которые дают Вам выносливость и максимально быстрое восстановление.",
                Weight = 435,
                Cost = 65.00m,
                ImageId = 7,
                TypeId = 1,
                CategoryId = 4
            };
            Product p8 = new Product
            {
                Id = 8,
                Name = "SUPER OMEGA-3",
                ShortDescription = "Высококачественное концентрированное масло океанской рыбы, которая является богатым источником жирных кислот группы Omega-3 (EPA и DHA). Жирные кислоты Super Omega - 3 имеют основополагающее значение для надлежащего функционирования организма человека, особенно сердца и кровеносных сосудов.",
                FullDescription = "SUPER OMEGA-3 – это пищевая добавка, которая содержит в своем составе высококачественное концентрированное масло океанской рыбы (рыбий жир), которая является богатым источником жирных кислот группы Omega-3 (ЭПК и ДГК). Эти кислоты имеют основополагающее значение для надлежащего функционирования нашего организма, особенно сердца и кровеносных сосудов. К сожалению, человеческий организм не способен их сам синтезировать, а наше питание из - за ограничений на потребление рыбы не пополняет его в этих компонентах.Недостаток их часто проявляется в виде проблем: метаболических(снижение обмена веществ, снижение выработки энергии из жира), иммунных(снижение сопротивляемости инфекциям, склонность к воспалениям и частым аллергиям), эмоциональных(депрессия, гиперактивность), умственных(проблемы с концентрацией и памятью).Использование витаминов SUPER OMEGA оказывает существенное влияние на стимулирование умственного и физического потенциала нашего организма.",
                Weight = 120,
                Cost = 30.00m,
                ImageId = 8,
                TypeId = 2,
                CategoryId = 1
            };
            Product p9 = new Product
            {
                Id = 9,
                Name = "GOLD STANDART GAINER",
                ShortDescription = "Gold Standard Gainer от Optimum Nutrition – новый сбалансированный гейнер с оптимальным соотношением белков и углеводов – 1 к 2. Его база составлена из лучших смесей, где каждый ингредиент работает на результат",
                FullDescription = "В состав гейнера входят медленно усвояемые углеводы высокого качества из овсяной муки, горохового и картофельного крахмала, несколько видов белка (основной ингредиент этого гейнера – сывороточный изолят) и только полезные жиры – из льяного масла, семян чиа и среднецепочных триглицеридов. Углеводная матрица этого гейнера обеспечит вам длительный заряд энергии и поможет восстановить запасы гликогена, белковая матрица(изолят сыворотки, концентрат сыворотки, изолят молочного протеина, гидролизованный изолят сыворотки) снабдит организм необходимыми для мышечного роста и восстановления аминокислоты, при этом не нагружая ЖКТ.Полезные для организма жиры, входящие в состав этого гейнера, быстро усваиваются и сразу же начинают работать на пользу организма: помогают усвоению многих витаминов и транспорту гормонов, участвуют в процессе формирования клеточных мембран, терморегуляции и других.",
                Weight = 2250,
                Cost = 149.00m,
                ImageId = 9,
                TypeId = 1,
                CategoryId = 5
            };
            Product p10 = new Product
            {
                Id = 10,
                Name = "HYPER MASS 5000",
                ShortDescription = "Hyper Mass — это превосходное решение для интенсивно тренирующихся атлетов, которым нужны быстро усваивающиеся протеины и достаточное количество углеводов для проведения успешных тренировок. Hyper Mass богат незаменимыми аминокислотами с разветвленными боковыми ...",
                FullDescription = "Для набора мышечной массы необходимо огромное количество калорий. И не просто калорий, а качественных углеводов и белков. В составе гейнера Hyper Mass от BioTech - три вида углеводов с разными гликемическими индексами, а также комплекс из трех видов белка с различным временем усвоения: сывороточного, казеината кальция и изолята сывороточного белка. В составе только молочный белок, давно зарекомендовавший себя как отличный источник строительного материала для мышц. Благодаря высокой биологической ценности молочные белки обеспечивают тело аминокислотами для быстрого и эффективного набора мышечной массы. Вишенкой на торте будет микронизированный моногидрат креатин – целых 3 грамма на порцию! Теперь вы без труда можете пополнить рацион необходимым количеством калорий,необходимым для роста мышц.",
                Weight = 4000,
                Cost = 148.50m,
                ImageId = 10,
                TypeId = 1,
                CategoryId = 5
            };
            Product p11 = new Product
            {
                Id = 11,
                Name = "CREATINE MONOHYDRATE",
                ShortDescription = "Креатин моногидрат – это одна из ключевых добавок в силовых видах спорта, которая применяется для мощного повышения физической работоспособности.",
                FullDescription = "Креатин моногидрат – это одна из ключевых добавок в силовых видах спорта, которая применяется для мощного повышения физической работоспособности. Креатин значительно повышает силовые показатели, выносливость, увеличивает мышечные объемы за счет повышенной гидратации клеток. Также добавка способна выступать буфером молочной кислоты, что позволяет мышцам дольше находится под нагрузкой до наступления отказа.",
                Weight = 250,
                Cost = 20.00m,
                ImageId = 11,
                TypeId = 1,
                CategoryId = 6
            };
            Product p12 = new Product
            {
                Id = 12,
                Name = "CREATINE RULE ONE",
                ShortDescription = "Креатин является очень важной добавкой в рационе спортсмена. Он является природным метаболитом и даже производится организмом самостоятельно, также он находится в еде. Преимущественно в мясных продуктах. Но чтобы получить хотя бы 2 грамма креатина из еды, необходимо съесть килограмм чистого красного мяса.",
                FullDescription = "Креатин Creatine Rule One R1 представленный в своей классической форме креатина моногидрата. Креатин является очень важной добавкой в рационе спортсмена.Он является природным метаболитом и даже производится организмом самостоятельно, также он находится в еде.Преимущественно в мясных продуктах.Но чтобы получить хотя бы 2 грамма креатина из еды, необходимо съесть килограмм чистого красного мяса. Креатин участвует в построении АТФ - основного топливного компонента мышц.Также креатин задерживает воду в клетках, что создает благоприятную анаболическую среду для роста и восстановления мышцы.",
                Weight = 375,
                Cost = 32.00m,
                ImageId = 12,
                TypeId = 1,
                CategoryId = 6
            };

            Role r1 = new Role
            {
                Id = 1,
                Name = "Admin"
            };
            Role r2 = new Role
            {
                Id = 2,
                Name = "User"
            };

            User u1 = new User
            {
                Id = 1,
                Nickname = "admin",
                Email = "admin@mail.ru",
                Password = "123456",
                RoleId = 1,
                TotalSpentMoney = 0
            };
            User u2 = new User
            {
                Id = 2,
                Nickname = "user",
                Email = "user@mail.ru",
                Password = "123456",
                RoleId = 2,
                TotalSpentMoney = 0
            };
            User u3 = new User
            {
                Id = 3,
                Nickname = "Ivan",
                Email = "ivan@mail.ru",
                Password = "123456",
                RoleId = 2,
                TotalSpentMoney = 0
            };
            User u4 = new User
            {
                Id = 4,
                Nickname = "Petya",
                Email = "petya@mail.ru",
                Password = "123456",
                RoleId = 2,
                TotalSpentMoney = 0
            };

            Place pl1 = new Place
            {
                Id = 1,
                ShopName = "FitFood",
                Street = "Колесникова",
                House = 3,
                HouseAdditionalLetter = "Б"
            };
            Place pl2 = new Place
            {
                Id = 2,
                ShopName = "FitFood",
                Street = "Дунина-Мартинкевича",
                House = 18,
                HouseAdditionalLetter = "/4"
            };
            Place pl3 = new Place
            {
                Id = 3,
                ShopName = "FitFood",
                Street = "Игнатовского",
                House = 33,
                HouseAdditionalLetter = ""
            };

            Review rev1 = new Review
            {
                Id = 1,
                Title = "Отличный товар",
                Content = "Хорошо себя зарекомендовал",
                Pluses = "Приятный вкус",
                Minuses = "Высокая цена",
                ReviewDate = DateTime.Now,
                Stars = 3,
                ProductId = 1,
                UserId = 1,
            };

            Review rev2 = new Review
            {
                Id = 2,
                Title = "Рекомендую!",
                Content = "Товар соответствует всем ожиданиям",
                Pluses = "Приятная цена",
                Minuses = "Невкусно",
                ReviewDate = DateTime.Now,
                Stars = 5,
                ProductId = 1,
                UserId = 2,
            };

            Review rev3 = new Review
            {
                Id = 3,
                Title = "Хорошо",
                Content = "Мне понравилось",
                Pluses = "Хватает на месяца 3",
                Minuses = "Дорого",
                ReviewDate = DateTime.Now,
                Stars = 4,
                ProductId = 2,
                UserId = 2,
            };

            db.Categories.Add(c1);
            db.Categories.Add(c2);
            db.Categories.Add(c3);
            db.Categories.Add(c4);
            db.Categories.Add(c5);
            db.Categories.Add(c6);
            db.AggregateTypes.Add(at1);
            db.AggregateTypes.Add(at2);
            db.AggregateTypes.Add(at3);

            db.Images.Add(i1);
            db.Images.Add(i2);
            db.Images.Add(i3);
            db.Images.Add(i4);
            db.Images.Add(i5);
            db.Images.Add(i6);
            db.Images.Add(i7);
            db.Images.Add(i8);
            db.Images.Add(i9);
            db.Images.Add(i10);
            db.Images.Add(i11);
            db.Images.Add(i12);

            db.Products.Add(p1);
            db.Products.Add(p2);
            db.Products.Add(p3);
            db.Products.Add(p4);
            db.Products.Add(p5);
            db.Products.Add(p6);
            db.Products.Add(p7);
            db.Products.Add(p8);
            db.Products.Add(p9);
            db.Products.Add(p10);
            db.Products.Add(p11);
            db.Products.Add(p12);

            db.Roles.Add(r1);
            db.Roles.Add(r2);
            db.Users.Add(u1);
            db.Users.Add(u2);
            db.Users.Add(u3);
            db.Users.Add(u4);
            db.Places.Add(pl1);
            db.Places.Add(pl2);
            db.Places.Add(pl3);

            db.Reviews.Add(rev1);
            //db.Reviews.Add(rev2);
            db.Reviews.Add(rev3);

            db.SaveChanges();

            base.Seed(db);
        }
    }
}