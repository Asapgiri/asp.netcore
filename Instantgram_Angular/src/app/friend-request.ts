import { User } from './user';

export class FriendRequest {
  public Friend: User
  constructor(friend: User) {
    this.Friend = friend
  }
}
