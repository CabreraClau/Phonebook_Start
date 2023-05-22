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
        //eliminar un contacto de la lista persons
        public void Remove(Contact contact)
        {
            this.persons.Remove(contact);
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
            
        }
}