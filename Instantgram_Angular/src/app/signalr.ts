import { Predicate } from '@angular/core';
import * as signalR from '@aspnet/signalr'
import { Post } from './post';

export class Signalr {
  private hubConnection: signalR.HubConnection;

  constructor(uri: string) {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(uri)
      .build()
  }

  register(methodname: string, method: Predicate<Post>) {
    this.hubConnection.on(methodname, method)
  }

  start() {
    this.hubConnection.start()
      .then(() => console.log('Connection stared !!'))
      .catch(err => console.log('Error occured with connection: ', err))
  }
}
