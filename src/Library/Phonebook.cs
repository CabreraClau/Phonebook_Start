using System.Collections.Generic;

namespace Library
{
    public class Phonebook
    {
        
        // atributo privado persons, lista de contact, --> contactos almacenados
        //Owner propietario de agenda x
        //creo lista vacia para almacenar contactos
        public Phonebook(Contact owner)
        {
            this.Owner = owner;
            this.persons = new List<Contact>();
        }
        private List<Contact> persons;

        public Contact Owner { get; }
        
        
        //agregar un contacto a la lista persons
        public void Add(string name)
        {
            Contact contact = new Contact(name);
            this.persons.Add(contact);
        }
        

        public List<Contact> Search(string[] names)
        {
            List<Contact> result = new List<Contact>();

            foreach (Contact person in this.persons)
            {
                foreach (string name in names)
                {
                    if (person.Name.Equals(name))
                    {
                        result.Add(person);
                    }
                }
            }

            return result;
        }
        //Metodo para enviar mensajes a canales
        public void SendMessageChannel(string text, IMessageChannel channel, string[] name)
        {
            // Hace que a la lista de contactos ya creada mande el mensaje a sus destinatarios, creando la instancia Message
            //Para esto tuve que hacer public message (estaba protegida)
            //
            foreach (Contact reciever in Search(name))
            {
                Message message = new Message(this.Owner.Name, reciever.Name);
                message.Text = text;
                channel.Send(message,reciever);
            }
            
        }
    }
}