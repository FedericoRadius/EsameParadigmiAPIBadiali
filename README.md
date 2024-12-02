In teoria per il dump del database basta fare doppio click e aprirlo con sqlServer
Poi bisogna creare un utente, il controller degli utenti non richiede l'autenticazione
tramite username e password si richiede un token di accesso al controller dei token
si mette il token nell'autorizzazione con bearer che lo precede
ora si possono usare anche gli altri due controller, quello dei libri e delle etichette
