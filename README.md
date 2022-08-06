
# PhotosiDemo


### 1. UserAPI
### 2. ProductApi
### 3. OrderApi
### 4. AddressApi
### 5. Phosi.Test
### 6. Docker



il progetto diviso in 4 webapi è strutturato come se fossero 4 microservizi indipendenti

che negli scenari di produzione è possibile scalare aumentando il numero di istanze 

piu' un progetto di test avviabile da visual studio

ci sono 4 database 1 per ogni progetto



ogni API crea il suo db all'avvio

nei test si usa un db in memoria 

per provare le API è necessario un db mysql

all' avvio di ogni API viene creato il relativo DB

ogni WEBApi ha il suo file di configurazione presente nel appsettings.json relativo

per API è possible usare `Swagger` per fare i test sulla relativa porta


### 1. UserAPI

esempio

`http://localhost:5142/swagger/index.html`

relativo alla UserAPI ha 3 metodi

<ul>
  <li>/api/v1/User/Login</li>
  <li>/api/v1/User/AddUser</li>
  <li>/api/v1/User/UpdateUser</li>
</ul>



il metodo `AddUser` serve per creare l'utente

il metodo `UpdateUser` per aggiornarlo 

il metodo `Login` per ottenere id dell' utente passando 2 parametri username e la password

ogni operazione restituisce una classe DTO i cui elementi vengono valorizzati dall' Automapper

da notare che non deve mai essere presente la password quando ritorna utente, 

la password è cryttografata nel db con un semplice hash

```c#
  public class UserDTO 
    {
        public string Id { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
```
### 2. ProductAPI

ProductAPI ha 4 metodi

<ul>
  <li>/api/v1/ProductApi/AddProduct</li>
  <li>/api/v1/ProductApi/UpdateProduct</li>
  <li>/api/v1/ProductApi/RemoveProduct</li>
  <li>/api/v1/ProductApi/SearchProduct</li>
</ul

un prodotto ha 

```json
{ 
  "name": "string",
  "category": "string",
  "price": 10
}
 ```

la categoria non essendoci un db puo' essere una stringa come da esempio "computer", "tablet","elettronica", ecc...

metodo `AddProduct` aggiunge prodotto
metodo `UpdateProduct` modifica prodotto è possibile cambiare nome , quantità e prezzo del prodotto
metodo `RemoveProduct` cancella dal db prodotto

il metodo SearchProduct permette di fare la ricerca di 1 o piu' prodotti con dei filtri e permette la paginazione

questa e la classe model

da notare `PriceMax` e `PriceMin` per fare ricerche su un range di prezzi

`Page` e `PageSize` per la paginazione con 1 si intende la prima pagina con max 10 elementi

 ```c#

   public class SearchProduct
    {
        public string Name { get; set; } = string.Empty;
    
        public string Category { get; set; } = string.Empty;

        public decimal PriceMin { get; set; }

        public decimal PriceMax { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10; 
    }
```

verrà restituita una relativo classe `ProductDTO` con il relativo numero di pagine e gli elementi per pagina

questo è importante perche relativamente un db puo' contenere migliaia di prodotti

```c#
   public class ProductDTO 
    {
             
        public long Id { get; set; }
  
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public long Pages { get; set; }

        public int PageSize { get; set; }
    }

```
### 3. OrderAPI
  
 OrderAPI ha 3 metodi

 
<ul>
  <li>/api/v1/Order/SaveOrder</li>
  <li>/api/v1/Order/ModifyOrder</li>
  <li>/api/v1/Order/SearchOrderByUserdId</li>
</ul>
 
 
 per inserire ordine è necessario conoscere
   
   #### userId
   #### addressId
   #### productId
 
 che devono essere recuperati dalle altre API
  
 un ordine è composta dall' oggetto `Order` che puo' contenere piu' `OrderDetail`  (dettagli dell' ordine)
   
 dove ogni dettaglio ha una quantità del prodotto , id del prodotto, relativo ordine id che serve per mantenere la relazione tra le due tabelle 
 
 ##### Order
 ##### OrderDetail

## Order
 ```json
{
  "orderId": 0,
  "userId": 0,
  "userName": "string",
  "addressId": 0,
  "orderDetail": [
    {
      "orderId": 0,
      "quantity": 0,
      "productId": 0
    }
  ]
}

```
è possibile successivamente modificare ordine conoscendo i dati dell' ordine precedente ad ogni operazione viene sempre restituita classe DTO

```c#
   public class OrderDTO
    {

        public long OrderId { get; set; }
     
        public int UserId { get; set; } = string.Empty;
       
        public long AddressId { get; set; } = string.Empty;
      
        public virtual ICollection<OrderDetailDTO>? OrderDetail { get; set; }

    }
    
    public class OrderDetailDTO
    {
   
        public int Quantity { get; set; }
        
        public long OrderId { get; set; } = string.Empty;
       
        public long ProductId { get; set; } = string.Empty;
    }

```
 
 il metodo `SearchOrderByUserId` permette di cercare tutti gli ordini per id utente
 il metodo `SearchOrderByUserName` permette di cercare ordini per username ma è stato aggiunto solo per comodità

  ### 4. AddressAPI
  
  AddressAPI ha 3 metodi
  <ul>
  <li>/api/v1/Address/Address</li>
  <li>/api/v1/Address/SaveAddress</li>
  <li>/api/v1/Address/SearchAddress</li>
  </ul>

 


 
 funzionamento simili alle precedente anche qui  SearchAddress ha la paginazione ipotizzando che gli indirizzi potrebbero essere milioni
 ci sono vari filtri possibile cercare per Address specificando anche una stringa parziale
 e per city,postalcode,country
 
 
 ```c#
 
   public class SearchAddress
    {
       
        public string Addres { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;

    }

```

### 5. Photosi.Test 

il test viene eseguito recuperando dalle relative dipendenze dei vari progetti API i vari services

viene usato un db in memoria per ovviare all' inconveniente di avere un db non disponibile

sono presenti 2 file csv per simulare inserimento di Address (address.csv)  e Prodotti (prodotti.csv)

è importante che siano entrambi dentro il path specificato dell' app.config perche questi cambiano in base al tipo ambiente 

esempio
`<add key="pathCsv" value="C:\\Users\\nturri\\source\\repos\\WebPhotosi\\Photosi.Test\\CSV"/>`


il progetto dei test contiene 4 classi

#### TestUser

viene simulato la creazione user con una password generata
viene fatto update dell' utente cambiando email
infine viene fatto login utente se va tutto a buon fine test e positivo

#### TestAddress

vengono inseriti dal file csv degli indirizzi e viene controllato se il numero di elmenti corrisponde


#### TestProducts

vengono inseriti dei prodotti da file csv e viene simulato anche un cambio di prezzo


#### TestOrder

viene creato un ordine con il dettaglio , viene simulato un cambio ordine sulla quantità del prodotto

 
  
### 6. Docker  
  
  ![Immagine di docker](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQJBp0wO5DU0UofZlRMBBaM8d_IB7nbgcX3KA&usqp=CAU)


è stato aggiornato il docker-compose è possibile fare deploy di tutte le api insieme al db mysql

siccome la creazione del db è piu' lenta le api potrebbero andare in errore quando non trovano il db

ma basta riavviarle da console o meglio da docker-desktop se si usa windows



ho aggiunto anche le immagini docker al registry del `DockerHub` 

sono utili quando si vuole usare `docker-compose` su un server dove non c'e visual studio o per gli ambienti di produzione

  ```c#

docker pull nicola1306/userapi:dev

docker pull nicola1306/productapi:latest

docker pull nicola1306/adresssapi:latest

docker pull nicola1306/orderapi:latest
 ```

 







