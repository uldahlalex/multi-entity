import {MyApi} from "@/App.tsx";
import type {Book} from "@/api/Api.ts";
import {useState} from "react";

interface BookComponentProps {
    b: Book
    setBooks: (books: Book[]) => void;
}

export function BookComponent({b, setBooks}: BookComponentProps) {

    const [newBookTitle, setNewBookTitle] = useState(b.title)

    return <div key={b.id}>Book title: {b.title}
        <button onClick={() => {
            MyApi.deleteBook.libraryDeleteBook({bookId: b.id}).then(r => {
                MyApi.getBooks.libraryGetBooks().then(r => {
                    setBooks(r)
                })
            })
        }}>Delete this book
        </button>

        <input value={newBookTitle}
               onChange={e =>
                   setNewBookTitle(e.target.value)} />
        <button onClick={() => {
            MyApi.updateBook.libraryUpdateBook({NewBookTitle: newBookTitle, BookIdForLookup: b.id}).then(r => {
                MyApi.getBooks.libraryGetBooks().then(r => {
                    setBooks(r)
                })
            })
        }}>Update book with the new title</button>
    </div>
}