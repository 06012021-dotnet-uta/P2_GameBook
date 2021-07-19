import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DiscussionService } from '../discussion.service';
import { Observable } from 'rxjs';

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
    private httpClient: HttpClient,
    private discussionService: DiscussionService
  ) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts(){
    this.httpClient.get<any>('https://localhost:44350/api/Post/postids').subscribe(
      response => {
        console.log(response);
        this.posts = response;
      }
    )
  }

//   add(post: string): void {
//     post = post.trim();
//     if (!post) { return; }
//     this.discussionService.addPost({ post } as Post)
//       .subscribe(post => {
//         this.posts.push(post);
//       });
//   }

//   addPost(post: Post): Observable<Post> {
//     return this.httpClient.post<Post>('https://localhost:5001/api/Post', post, this.httpOptions).pipe(
//       tap((newHero: Post) => this.log(`added post w/ id=${newPost.id}`)),
//       catchError(this.handleError<Post>('addPost'))
//     );
//   }
}
