import { ICategory } from "./category.model";

export interface INewsList {
    news: INews[];
    count: number;
}

export interface INews{
    id: number;
    createdAt: Date;
    title: string;
    text: string;
    comment: boolean;
    categoryId: number;
    like: number;
    dislike: number;
    photos: IPhoto[];
    mainPhoto: IPhoto;
    view: number;
    videoLink?: any;
    category: ICategory;
    liked:boolean;
    disliked:boolean

}
export interface IPhoto{
    orderBy: number;
    main: boolean;
    image: string;
    newsId: number;
    id: number;
}