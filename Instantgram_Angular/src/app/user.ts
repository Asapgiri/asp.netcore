import { Post } from './post'

export class User {
  public Id: string = ''
  public userName: string = ''
  public password: string = ''
  public email: string = ''
  public dateOfBirth: string = ''
  public lastname: string = ''
  public firstname: string = ''
  public created: string = ''
  public modified: string = ''
  public posts: Array<Post> = []
}
