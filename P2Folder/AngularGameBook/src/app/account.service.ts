import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor() { }
}

export interface PlayHistory {
  userId: number,
  gameId: number,
}

export interface Friend {
  user1Id: number,
  user2Id: number,
}