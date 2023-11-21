namespace RPG
{
    class Bohater
    {
        protected string name;
        public int hp { get; protected set; }
        protected int sp;
        protected int mp;

        public Bohater(string name, int hp, int sp, int mp=0)
        {
            this.name = name;
            this.hp = hp;
            this.sp = sp;
            this.mp = mp;
        }
        public virtual int atak() { return 0; }
        public virtual void dmg(int n) {  }
        public override string ToString()
        {
            var m = mp > 0 ? $" mp: {mp};" : "";
            return $"Bohater: {name}; {hp} hp; {sp} sily;" +m;
        }
    }
    class Rycerz : Bohater
    {
        Random rnd = new Random();
        public Rycerz(string name, int hp, int sp, int mp=0)
            : base(name, hp, sp, mp) { }
        public override string ToString()
        {
            return base.ToString();
        }
        public override int atak() {
            int atack = (int)(rnd.Next(0, sp + 1) * (1.0*hp / 100));
            Console.WriteLine($"{name} uderza: {atack}");
            return atack;
        }
        public override void dmg(int n)
        {
            hp = hp - n;
            if (hp < 0) hp = 0;
            Console.WriteLine($"{name} dostał {n} obrażeń. Zostało mu {hp}");
        }
    }
    class Mag : Bohater 
    {
        Random rnd = new Random();
        public Mag(string name, int hp, int sp, int mp = 0)
            : base(name, hp, sp, mp) { }
        public override string ToString()
        {
            return base.ToString();
        }
        public override int atak()
        {
            int atack = (int)((rnd.Next(0, sp + 1)+rnd.Next(0, mp+1)) * (1.0*hp / 100));
            Console.WriteLine($"{name} zadaje cios magiczny: {atack}");
            return atack;
        }
        public override void dmg(int n)
        {
            hp = hp - n;
            if (hp < 0) hp = 0;
            Console.WriteLine($"{name} dostał {n} obrażeń. Zostało mu {hp}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Mag harry = new Mag("Harry Potter", 100, 10, 20);
            Console.WriteLine(harry);
            Rycerz conan = new Rycerz("Conan barbarzyńca", 100, 30);
            Console.WriteLine(conan);
            while (true) { 
                conan.dmg(harry.atak());
                if(conan.hp==0) break;
                harry.dmg(conan.atak());
                if(harry.hp==0) break;
            }
            Console.WriteLine(harry);
            Console.WriteLine(conan);
            
        }
    }
}