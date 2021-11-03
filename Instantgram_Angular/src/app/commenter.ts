import { User } from './user'

export class Commenter {
  public message: string = ''
	public created: string = ''
	public lastModified: string = ''
	public author?: User
	public parentPostId: string = ''
}
