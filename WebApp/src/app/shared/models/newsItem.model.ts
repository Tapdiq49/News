import { ICategory } from "./category.model";

export interface INewsItem {
    title: string;
    text: string;
    comment: boolean;
    categoryId: number;
    like: number;
    dislike: number;
    view: number;
    videoLink?: any;
    photos: IPhoto[];
    category: ICategory;
    id: number;
    createdAt: Date;
    mainPhoto: IPhoto;
    noneMainPhotos : IPhoto[];
}
export interface IPhoto {
    orderBy: number;
    main: boolean;
    image: string;
    id: number;
}

