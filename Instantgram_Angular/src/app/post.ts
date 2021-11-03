import { Commenter } from './commenter'
import { Like } from './like'
import { User } from './user'

export class Post {
  public postId: string = ''
  public contentType: string = ''
  public location: string = ''
  public created: string = ''
  public modified: string = ''
  public author?: User
  public likes: number = 0
  public comments?: Array<Commenter>
}
