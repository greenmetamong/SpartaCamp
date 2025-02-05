using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace SpartaDungeon_TextRPG
{
    public class OpeningScene
    {
        //게임 오프닝 화면
        public OpeningScene()
        {
            Console.WriteLine("스파르타 던전 ver.1");
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine("스파르타 던전은 텍스트 RPG게임 입니다.");
            Console.WriteLine("몬스터를 처치하며 자신을 단련하여 스파르타 세계에서 살아 남으십시오.");
            Console.WriteLine();
            Thread.Sleep(500);

            while (true)
            {
                Console.Write("스파르타의 세계에 참여하시겠습니까?(Y/N) ");
                string Start = Console.ReadLine();

                if (Start == "Y" || Start == "y")
                {
                    Console.WriteLine("게임을 시작하겠습니다. 잠시만 기다려 주십시오");
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.Clear();
                    Thread.Sleep(500);
                    Console.WriteLine("스파르타 마을에 오신 것을 환영합니다.");
                    Thread.Sleep(1000);
                    break;
                }
                else if (Start == "N" || Start == "n")
                {
                    Console.WriteLine("게임을 종료합니다.");
                    Thread.Sleep(2000);
                    Console.WriteLine("기다려 주십시오. 게임을 다시 시작하는 중입니다.");
                    Thread.Sleep(3000);
                    continue;
                }
                else
                {
                    Console.WriteLine("제대로 된 값을 입력해주세요.");
                    continue;
                }
            }
        }
    }
    //게임 시작 화면
    public class MainScene
    {
        Player player;
        static ItemData itemData = new ItemData();
        List<Item> itemList = itemData.GetItemList();

        //행동 입력을 명령하는 Console
        public void ActInputConsole()
        {
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
        }

        //주어진 숫자 이외 입력 시
        public void WrongInput()
        {
            Console.WriteLine("잘못된 입력입니다.");
            Console.WriteLine("아무키를 눌러주세요.");
            Console.ReadLine();
        }

        public MainScene(Player player)
        {
            this.player = player;

            while (true)
            {
                //메인 로비 대사 창
                Console.Clear();
                Console.WriteLine("[스파르타 마을]");
                Console.WriteLine("이곳은 던전으로 들어가기 전 여러 활동을 할 수 있는 곳 입니다.");
                Thread.Sleep(500);
                Console.WriteLine("당신이 할 일을 선택할 수 있습니다.");
                Thread.Sleep(500);
                Console.WriteLine();
                Console.WriteLine("1. 거울로 내 상태 보기");
                Console.WriteLine("2. 가방 열어 인벤토리 보기");
                Console.WriteLine("3. 상점 가기");
                Console.WriteLine("4. 여관에서 휴식하기");
                Console.WriteLine("5. 던전 들어가기");
                Console.WriteLine();
                ActInputConsole();

                int select = int.Parse(Console.ReadLine());

                if (select == 1)
                {
                    PlayerInfoScene();
                }
                else if (select == 2)
                {
                    InventoryScene();
                }
                else if (select == 3)
                {
                    StoreScene();
                }
                else if (select == 4)
                {
                    MotelScene();
                }
                else if (select == 5)
                {
                    DungeonScene();
                }
                else
                {
                    WrongInput();
                }
            }
        }


        //여관 보기 창
        public void MotelScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[여관]");
                Console.WriteLine("이곳은 휴식등을 취할 수 있는 곳입니다.");
                Thread.Sleep(500);
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.Gold}G");
                Console.WriteLine();
                Console.WriteLine("[현재 체력]");
                Console.WriteLine($"{player.Health}G");
                Console.WriteLine();
                Thread.Sleep(500);
                Console.WriteLine("선택창)");
                Console.WriteLine("1) 휴식");
                Console.WriteLine("2) ♥");
                Console.WriteLine("0) 나가기");
                Console.WriteLine();
                ActInputConsole();

                int select = int.Parse(Console.ReadLine());


                if (select == 1)
                {
                    if (player.Health >= 100 || player.Gold < 100)
                    {
                        Console.WriteLine("더이상 체력을 회복할 수 없습니다. 마을로 돌아갑니다.");
                        Thread.Sleep(500);
                        return;
                    }
                    else
                    {
                        player.Health += 10;
                        player.Gold -= 100;
                        Console.WriteLine("z");
                        Thread.Sleep(100);
                        Console.WriteLine("z");
                        Thread.Sleep(100);
                        Console.WriteLine("z");
                        Thread.Sleep(100);
                        Console.WriteLine("Z");
                        Thread.Sleep(500);
                        Console.WriteLine("체력이 10 회복 되었습니다.");
                        Console.WriteLine("골드가 100 감소 하였습니다.");
                        Thread.Sleep(1000);
                    }

                }
                else if (select == 0)
                {
                    return;
                }
                else if (select == 2)
                {
                    if (player.Health > 10)
                    {
                        player.Health -= 10;
                        player.Gold += 100;
                        Console.WriteLine("♡");
                        Thread.Sleep(100);
                        Console.WriteLine("♡");
                        Thread.Sleep(100);
                        Console.WriteLine("♡");
                        Thread.Sleep(100);
                        Console.WriteLine("♥");
                        Thread.Sleep(500);
                        Console.WriteLine("체력이 10 감소 하였습니다.");
                        Console.WriteLine("골드가 100 증가 하였습니다.");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("더이상 사랑을 나눌 수 없습니다. 마을로 돌아갑니다.");
                        Thread.Sleep(500);
                        return;
                    }

                }
                else
                {
                    WrongInput();
                }
            }

        }

        //던전 보기 창
        public void DungeonScene()
        {
             while (true)
            {
                Console.Clear();
                Console.WriteLine("[던전 입구]");
                Console.WriteLine("이곳은 몬스터들과 전투하여 레벨을 올릴 수 있는 곳입니다.");
                Console.WriteLine();
                Thread.Sleep(500);
                Console.WriteLine();
                Console.WriteLine("1. 피츄 숲  ");
                Console.WriteLine("2. 피카츄 숲");
                Console.WriteLine("3. 라이츄 숲");
                Console.WriteLine();
                Thread.Sleep(500);
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Thread.Sleep(500);
                ActInputConsole();

                int select = int.Parse(Console.ReadLine());
                
                if (select == 0)
                {
                    return;
                }
                else if(select == 1)
                {
                   // DungeonSceneLv1();
                }
                else if (select == 2)
                {
                   // DungeonSceneLv2();
                }
                else if (select == 3)
                {
                    //DungeonSceneLv3();
                }
                else
                {
                    WrongInput();
                }
            }
        }

        //상태 보기 창
        public void PlayerInfoScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[상태창]");
                Console.WriteLine("이곳은 필요한 아이템을 얻을 수 있는 곳입니다.");
                Thread.Sleep(500);
                Console.WriteLine();
                Console.WriteLine($"Lv {player.Level}");
                Console.WriteLine($"{player.Name} ( {player.Job} )");
                Console.WriteLine($"공격력 : {player.AttackPower}");
                Console.WriteLine($"방어력 : {player.ProtectPower}");
                Console.WriteLine($"체력 : {player.Health}");
                Console.WriteLine($"Gold : {player.Gold}");
                Console.WriteLine();
                Thread.Sleep(500);
                Console.WriteLine("선택창)");
                Console.WriteLine("0) 나가기");
                Console.WriteLine();
                ActInputConsole();

                int select = int.Parse(Console.ReadLine());

                if (select == 0)
                {
                    return;
                }
                else
                {
                    WrongInput();
                }
            }
        }

        //상점 보기창
        public void StoreScene()
        {
            while (true)
            {
                ItemMenuConsole();
                foreach (Item item in itemList)
                {
                    item.DisplayItemBuy();
                }
                Thread.Sleep(500);
                Console.WriteLine();
                Console.WriteLine("선택창)");
                Console.WriteLine("1) 아이템 구매");
                Console.WriteLine("0) 나가기");
                Console.WriteLine();
                Thread.Sleep(500);
                ActInputConsole();

                int select = int.Parse(Console.ReadLine());

                if (select == 0)
                {
                    return;
                }
                else if (select == 1)
                {
                    ItemBuy();
                }
                else
                {
                    WrongInput();
                }
            }
        }

        //인벤토리 보기창
        public void InventoryScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");
                Thread.Sleep(500);

                if (player.Inventory.Count == 0)
                {
                    Console.WriteLine("『----------------------------------------------------");
                    Console.WriteLine("              보유한 아이템이 없습니다.");
                    Console.WriteLine("  ----------------------------------------------------』");
                }
                else
                {
                    for (int i = 0; i < player.Inventory.Count; i++)
                    {
                        player.Inventory[i].DisplayeItemEquip();
                    }
                }

                Console.WriteLine();
                Thread.Sleep(500);
                Console.WriteLine("선택창)");
                Console.WriteLine("1) 장착관리");
                Console.WriteLine("0) 나가기");
                Thread.Sleep(500);
                Console.WriteLine();
                ActInputConsole();

                int selcet = int.Parse(Console.ReadLine());

                if (selcet == 0)
                {
                    return; 
                }
                else if (selcet == 1)
                {
                    ItemEquip();
                }
                else
                {
                    WrongInput();
                }
            }
        }

        //장비를 장착한다고 했을때
        public void ItemEquip()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[아이템 목록]");
                Thread.Sleep(500);

                if (player.Inventory.Count == 0) 
                {
                    Console.WriteLine("보유한 아이템이 없습니다.");
                }

                else
                {
                    for (int i = 0; i < player.Inventory.Count; i++)
                    {
                        player.Inventory[i].DisplayeItemEquipIn(i);
                    }
                }

                Console.WriteLine();
                Thread.Sleep(500);
                Console.WriteLine("선택창)");
                Console.WriteLine("n) 장착 / 해제 할 아이템 번호를 입력하세요.");
                Console.WriteLine("0) 나가기");
                Thread.Sleep(500);
                Console.WriteLine();
                ActInputConsole();

                int select = int.Parse(Console.ReadLine());

                if (select == 0)
                {
                    return;
                }

                if (select < 1 || select > player.Inventory.Count)
                {
                    WrongInput();
                }

                //선택한 아이템 목록
                Item selectedItem = player.Inventory[select - 1];

                if (selectedItem.IsEquip)
                {
                    selectedItem.IsEquip = false;
                    player.EquipItem.Remove(selectedItem);
                    player.AttackPower -= selectedItem.AttackPower;
                    player.ProtectPower -= selectedItem.ProtectPower;
                    Console.WriteLine($"{selectedItem.Name}을(를) 해제했습니다!");
                    Console.WriteLine("전보다 약해진 것 같습니다.");
                    Thread.Sleep(500);
                    Console.WriteLine("아무키를 눌러주세요.");
                }

                else
                {
                    selectedItem.IsEquip = true;
                    player.EquipItem.Add(selectedItem);
                    player.AttackPower += selectedItem.AttackPower;
                    player.ProtectPower += selectedItem.ProtectPower;
                    Console.WriteLine($"{selectedItem.Name}을(를) 장착했습니다!");
                    Console.WriteLine("전보다 강해진 것을 느낍니다.");
                    Thread.Sleep(500);
                    Console.WriteLine("아무키를 눌러주세요.");
                }
                Console.ReadLine();
            }

        }

        //아이템을 산다고 했을때 구매에 따른 메서드
        public void ItemBuy()
        {
            ItemMenuConsole();
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].DisplayeItemBuyIn(i);
            }
            Console.WriteLine();
            Console.WriteLine("선택창)");
            Console.WriteLine("N) 구매를 원하는 아이템 번호를 입력하세요.");
            Console.WriteLine("0) 나가기");
            Console.WriteLine();
            Console.Write(">> ");
            int select = int.Parse(Console.ReadLine());

            if (select == 0) return; //나가기

            if (select < 1 || select > itemList.Count)  // 잘못된 입력 방지
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.ReadLine();
                return;
            }

            Item selectedItem = itemList[select - 1];  // 선택한 아이템 가져오기

            if (selectedItem.IsPurchase)  // 이미 구매한 경우
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
            else if (player.Gold < selectedItem.Price)  // 골드 부족
            {
                Console.WriteLine("골드가 부족합니다.");
            }
            else
            {
                player.Gold -= selectedItem.Price; // 플레이어 골드 차감
                selectedItem.IsPurchase = true;
                player.Inventory.Add(selectedItem);  // 인벤토리에 추가

                Console.WriteLine($"{selectedItem.Name}을(를) 구매했습니다!");
                Thread.Sleep(500);
                Console.WriteLine("구매하신 아이템은 인벤토리에 가서 착용 하시길 추천드립니다.");
                Thread.Sleep(500);
                Console.WriteLine("아무키를 눌러주세요.");
            }
            Console.ReadLine();
        }

        public List<Item> Iventory()
        {
            List<Item> Inventory = new List<Item>();
            foreach (Item item in itemList)
            {
                if (item.IsPurchase)
                {
                    Inventory.Add(item);
                }
            }
            return Inventory;
        }

        //아이템 상점 메뉴 Console
        public void ItemMenuConsole()
        {
            Console.Clear();
            Console.WriteLine("[상점]");
            Console.WriteLine("이곳은 필요한 아이템을 얻을 수 있는 곳입니다.");
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Thread.Sleep(500);
        }
    }

    //아이템 클래스
    public class Item
    {
        public string Name { get; }
        public string Description { get; set; }
        public int Type { get; } // 무기: 1, 방어구:2
        public int AttackPower { get; }
        public int ProtectPower { get; }
        public int Price { get; set; }
        public bool IsEquip { get; set; }
        public bool IsPurchase { get; set; }

        //아이템 생성자 
        public Item(string name, string description, int type, int attackPower, int protectPower, int price, bool isEquip)
        {
            Name = name;
            Description = description;
            Type = type;
            AttackPower = attackPower;
            ProtectPower = protectPower;
            Price = price;
            IsEquip = false;
            IsPurchase = false;
        }

        //상점 내 아이템 구매창 
        public void DisplayItemBuy()
        {
            if (Type == 1)
            {
                if (IsPurchase == true)
                {
                    Console.WriteLine($"- {Name} | 공격력 +{AttackPower} | {Description} | 구매완료");
                }
                else Console.WriteLine($"- {Name} | 공격력 +{AttackPower} | {Description} | {Price} G");
                
            }
            else
            {
                if (IsPurchase == true)
                {
                    Console.WriteLine($"- {Name} | 방어력 +{ProtectPower} | {Description} | 구매완료");
                }
                else Console.WriteLine($"- {Name} | 방어력 +{ProtectPower} | {Description} | {Price} G");
            }

        }

       //상점 내 아이템 구매 선택시 표시창
        public void DisplayeItemBuyIn(int index)
        {
            if (Type == 1)
            {
                if (IsPurchase == true)
                {
                    Console.WriteLine($"- {Name} | 공격력 +{AttackPower} | {Description} | 구매완료");
                }
                else Console.WriteLine($"{index + 1} {Name} | 공격력 +{AttackPower} | {Description} | {Price} G");
                
            }
            else
            {
                if (IsPurchase == true)
                {
                    Console.WriteLine($"- {Name} | 방어력 +{ProtectPower} | {Description} | 구매완료");
                }
                else Console.WriteLine($"{index + 1} {Name} | 방어력 +{ProtectPower} | {Description} | {Price} G");
            }
        }

        //인벤토리 내 아이템 선택창에서 보여주는 표시
        public void DisplayeItemEquip()
        {
            if (Type == 1)
            {
                if (IsEquip == true) // 장착시 [E] 표시
                {
                    Console.WriteLine($"- [E]{Name} | 공격력 +{AttackPower} | {Description}");
                }
                else Console.WriteLine($"- {Name} | 공격력 +{AttackPower} | {Description}");

            }
            else
            {
                if (IsEquip == true) // 장착시 [E] 표시
                {
                    Console.WriteLine($"- [E]{Name} | 방여력 +{ProtectPower} | {Description}");
                }
                else Console.WriteLine($"- {Name} | 방여력+{ProtectPower} | {Description}");
            }
        }
        //인벤토리 내 아이템 장착시 보여주는 표시
        public void DisplayeItemEquipIn(int index)
        {
            if (Type == 1)
            {
                if (IsEquip == true) // 장착시 [E] 표시
                {
                    Console.WriteLine($"{index + 1} [E]{Name} | 공격력 +{AttackPower} | {Description}");
                }
                else Console.WriteLine($"{index + 1} {Name} | 공격력 +{AttackPower} | {Description}");

            }
            else
            {
                if (IsEquip == true) // 장착시 [E] 표시
                {
                    Console.WriteLine($"{index + 1} [E]{Name} | 방어력 +{ProtectPower} | {Description}");
                }
                else Console.WriteLine($"{index + 1} {Name} | 방어력 +{ProtectPower} | {Description}");
            }
        }
    }

    //플레이어 클래스
    public class Player
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; set; }
        public int AttackPower { get; set; }
        public int ProtectPower { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }

        public List<Item> Inventory { get; set; }
        public List<Item> EquipItem { get; set; }

        //플레이어 생성자
        public Player()
        {
            Name = "메타몽";
            Job = "전사";
            Level = 1;
            AttackPower = 10;
            ProtectPower = 5;
            Health = 100;
            Gold = 5000;
            Inventory = new List<Item>();
            EquipItem = new List<Item>();
        }

    }

    //아이템 정보관련 및 리스트화
    public class ItemData
    {
        private List<Item> items;

        public ItemData()
        {
            items = new List<Item>
            {
                new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 0, 5, 0, 1000, false),
                new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9, 0, 2000, false),
                new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 15, 0, 3500, false),
                new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.   ", 1, 0, 2, 600, false),
                new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다. ", 1, 0, 5, 1500, false),
                new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 1, 0, 7, 2000, false),
                //아이템 추가
                new Item("금속파우더", "메타몽에게 지니게 하면 방어가 올라가는 이상한 가루. 매우 잘고 단단하다.", 0, 0, 10, 1000, false)
            };
        }
        //기존 리스트 반환
        public List<Item> GetItemList()
        {
            return items;
        }
    }

    //던전 클래스


    class Program
    {
        static Player player = new Player();

        static void Main(string[] args)
        {
            OpeningScene scene = new OpeningScene();
            MainScene gameStartScene = new MainScene(player);
        }
    }
}