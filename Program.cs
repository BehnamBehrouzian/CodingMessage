class CodingMessage
{
    static void Main()
    {
        // تبدیل حرف به عدد به روش index
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        Console.Write("Please enter the sender's name: ");
        string sender = Console.ReadLine();

        Console.Write("Please enter the receiver's name: ");
        string receiver = Console.ReadLine();

        // تبدیل اسم فرستنده به عدد
        int senderSum = 0;
        foreach (char c in sender.ToLower())
        {
            if (char.IsLetter(c))
            {
                int index = alphabet.IndexOf(c) + 1;
                senderSum += index;
            }
        }

        // تبدیل اسم گیرنده به عدد
        int receiverSum = 0;
        foreach (char c in receiver.ToLower())
        {
            if (char.IsLetter(c))
            {
                int index = alphabet.IndexOf(c) + 1;
                receiverSum += index;
            }
        }

        // انتخاب روش محاسبه شیفت
        Console.WriteLine("Select the method to calculate the shift:");
        Console.WriteLine("1. First method (senderSum * receiverSum) / (senderSum + receiverSum)");
        Console.WriteLine("2. Second method (senderSum + receiverSum)");

        int methodChoice = 0;
        while (methodChoice != 1 && methodChoice != 2)
        {
            Console.Write("Enter 1 or 2: ");
            methodChoice = int.Parse(Console.ReadLine());

            // روش اول
            if (methodChoice == 1)
            {
                int shift = (senderSum * receiverSum) / (senderSum + receiverSum);
                shift = shift % 26;
                Console.WriteLine("The shift value (first method) is: " + shift);
                EncryptDecryptMessage(alphabet, shift);
            }
            // روش دوم
            else if (methodChoice == 2)
            {
                int shift = (senderSum + receiverSum) % 26;
                Console.WriteLine("The shift value (second method) is: " + shift);
                EncryptDecryptMessage(alphabet, shift);
            }
            else
            {
                // اگر غیر 1 و 2 بود
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }
        }
    }

    static void EncryptDecryptMessage(string alphabet, int shift)
    {
        Console.Write("Please enter the message to encrypt: ");
        string message = Console.ReadLine();

        // تبدیل پیام به عدد
        string encryptedMessage = "";
        foreach (char c in message)
        {
            // روش اول
            if (char.IsLetter(c))
            {
                int index = (alphabet.IndexOf(char.ToLower(c)) + shift) % 26;
                if (char.IsUpper(c))
                    encryptedMessage += Char.ToUpper(alphabet[index]);
                else
                    encryptedMessage += alphabet[index];
            }
            else
            {
                encryptedMessage += c;
            }
        }

        Console.WriteLine("Encrypted message: " + encryptedMessage);

        // رمزگشایی پیام
        string decryptedMessage = "";
        foreach (char c in encryptedMessage)
        {
            // روش دوم
            if (char.IsLetter(c))
            {
                int index = (alphabet.IndexOf(char.ToLower(c)) - shift + 26) % 26;
                if (char.IsUpper(c))
                    decryptedMessage += Char.ToUpper(alphabet[index]);
                else
                    decryptedMessage += alphabet[index];
            }
            else
            {
                decryptedMessage += c;
            }
        }

        Console.WriteLine("Decrypted message: " + decryptedMessage);
    }
}// از این بهتر میشه نوشت ولی متاسفانه هنوز بلد نیستم پس زیاد سخت نگیرید