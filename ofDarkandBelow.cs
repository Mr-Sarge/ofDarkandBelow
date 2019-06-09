using Terraria.ModLoader;

namespace ofDarkandBelow
{
    class ofDarkandBelow : Mod
    {
        public static ofDarkandBelow instance = null;

        public ofDarkandBelow()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }
        public override void Load()
        {
            instance = this;

            ModTranslation text = CreateTranslation("SkeletronBronzeMessage");
            text.SetDefault("The enemies in the underground hold Bronze!");
            AddTranslation(text);
        }
        public override void Unload()
        {
            instance = null;
        }
    }
}
