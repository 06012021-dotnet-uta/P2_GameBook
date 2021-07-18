import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class Post {
  constructor(
    public postId: number,
    public userId: number,
    public content: string,
    public postDate: Date,
    public commentParentId?: number,
  ) {
  }
}

@Component({
  selector: 'app-game-discussion',
  templateUrl: './game-discussion.component.html',
  styleUrls: ['./game-discussion.component.css']
})
export class GameDiscussionComponent implements OnInit {

  posts: Post[] | undefined;
  constructor(
    private httpClient: HttpClient
  ) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts(){
    this.httpClient.get<any>('https://localhost:5001/api/Post').subscribe(
      response => {
        console.log(response);
        this.posts = response;
      }
    )
  }
}
