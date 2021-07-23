import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Movie } from 'src/app/shared/models/Movie';
import { MovieService } from '../core/services/movie.service';
@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  //Router
  movie!: Movie;
  movieId!:Number; 
  constructor(private router:ActivatedRoute,private movieService :MovieService) { }
  // get the movieId from the URL  and call the MovieService , getMovieDetails Method 
  ngOnInit(): void {
    this.router.paramMap.subscribe(
      p=>{
       this.movieId = p.get('id');
       this.movieService.getMovieDetails(this.movieId).subscribe(
         m=>{
           this.movie = m;
         }
       );
      }
    )
  }
  

}
