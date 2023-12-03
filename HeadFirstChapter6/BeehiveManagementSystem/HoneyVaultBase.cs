using System;

namespace BeehiveManagementSystem
{
    static class HoneyVaultBase
    {
        public const float NECTAR_CONVERSION_RATION = .19f;
        public const float LOW_LEVEL_WARNING = 10f;

        private static float honey = 25f;
        private static float nectar = 100f;

        private static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;
            if (nectarToConvert > nectar) nectarToConvert = nectar;
            nectar -= nectarToConvert;
            honey += nectarToConvert * NECTAR_CONVERSION_RATION;
        }

        private static bool ConsumeHoney(float amount)
        {
            if (amount <= honey)
            {
                honey -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CollectNectar(float amount)
        {
            if (amount > 0) nectar += amount;
        }

        private static string StatusReport
        {
            get
            {
                string status = $"{honey:0.0} units of homey\n" +
                    $"{nectar:0.0} units of nectar";
                string warnings = "";
                if (honey < LOW_LEVEL_WARNING) warnings +=
                        "\nLOW HONEY - ADD A HONEY MANUFACTURER";
                if (nectar < LOW_LEVEL_WARNING) warnings +=
                        "\nLOW NECTAR - ADD A NECTAR COLLECTOR";
                return status + warnings;
            }
        }
    }
}