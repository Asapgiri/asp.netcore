import { DOCUMENT } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Commenter } from '../commenter';
import { Post } from '../post';
import { User } from '../user';
import { Inject }  from '@angular/core';
import { Signalr } from '../signalr';
import { PostCreate } from '../post-create';
import { CommentCreate } from '../comment-create';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public user?: User
  public router: Router
  public posts?: Array<Post>
  private http: HttpClient
  private token?: string
  public document: any
  private sr: Signalr
  private headers?: {}

  constructor(router: Router, http: HttpClient, @Inject(DOCUMENT) document: any) {
    this.document = document
    this.router = router
    this.http = http
    const username = sessionStorage.getItem('username')
    if (username) {
      this.user = new User()
      this.user.userName = username
      this.user.Id = sessionStorage.getItem('userID') || ''
      this.token = sessionStorage.getItem('token') || ''
      this.headers = {
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + this.token
      }
      this.loadContent();
    }
    /*else {
      this.user = new User()
      this.user.username = 'boboo'
      this.user.lastname = 'Oo'
      this.user.firstname = 'Bob'

      let post1: Post = new Post()
      let post2: Post = new Post()
      post1.created = (new Date()).toString()
      post2.created = (new Date()).toString()
      post1.type = 'Picture'
      post2.type = 'Video'
      post1.location = 'https://images6.fanpop.com/image/photos/36100000/Boss-This-image-boss-this-36181814-397-380.png'
      post2.location = 'https://www.youtube.com/watch?v=LbZ87XnkRBU'
      post1.likes = 5
      post2.likes = 10
      post1.comments = new Array<Commenter>()
      post1.postId = '1'
      post2.postId = '2'

      const comment1 = new Commenter()
      const comment2 = new Commenter()
      comment1.message = 'Hello'
      comment1.author = this.user
      comment2.message = 'Moshi-Moshi'
      comment2.author = this.user
      comment1.created = (new Date()).toString()
      comment2.created = (new Date()).toString()

      post1.comments.push(comment1, comment2)

      this.posts = new Array<Post>()
      this.posts.push(post1)
      this.posts.push(post2)
      console.log(this.posts)
    }*/
    //else this.router.navigate(['/explore'])
    this.sr = new Signalr('https://localhost:7766/postHub')
    this.sr.register('newPost', t => {
      this.posts?.push(t)
      return true
    })
    this.sr.start()
  }

  ngOnInit(): void {
  }

  loadContent() {
    console.log(this.headers)
    this.http.get<Post[]>('https://localhost:7766/home/home', {headers: this.headers}).subscribe(response => {
      this.posts = response
      console.log(response)
      console.log(this.posts)
    })
  }

  public sendMessage(message: HTMLInputElement, postId: string) {
    const comm: CommentCreate = new CommentCreate()
    comm.authorId = this.user?.Id || ''
    comm.message = message.value
    comm.parentPostId = postId

    this.http.put('https://localhost:7766/home/commentsend', comm, {headers: this.headers}).subscribe(response => {
      console.log(response)
    })

    message.value = ''
  }

  public createPost(type: HTMLSelectElement, location: HTMLInputElement) {
    const post = new PostCreate()
    post.authorId = sessionStorage.getItem('userID') || ''
    console.log(post.authorId)
    post.location = location.value
    post.type = type.value
    this.http.post('https://localhost:7766/home/newpost', post, {headers: this.headers}).subscribe(response => {
      console.log(response)
    })

    type.value = ''
    location.value = ''
  }

}
