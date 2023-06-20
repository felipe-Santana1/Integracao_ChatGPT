namespace EnglishTutorAPI.Models
{
    public class ChatGptInputModel
    {
        public ChatGptInputModel(string prompt)
        {

            //INICIANDO MODELO DE ENTRADA && DANDO FRASE DE NORTE
            this.prompt = $"Correct this English phrase: {prompt}";
            temperature = 0.2m;
            max_tokens = 100;
            model = "text-davinci-003";
        }

        public string model { get; set; } //Modelo Fixo
        public string prompt { get; set; } //Texto que iremos enviar
        public int max_tokens { get; set; } //Tokens maximos para ser gerado
        public decimal temperature { get; set; } //Valores maiores saidas amplas

    }
}
