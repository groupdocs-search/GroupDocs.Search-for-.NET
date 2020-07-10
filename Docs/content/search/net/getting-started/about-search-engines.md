---
id: about-search-engines
url: search/net/about-search-engines
title: About Search Engines
weight: 1
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
# About Search Engines

This page is about the classification of search engines and what place GroupDocs.Search API occupies in this classification. There are a large number of ways to classify search engines. Here are the main ones.

According to the search area, search engines can conditionally be divided into 3 groups:

*   Global. Global search engines are designed to search for information throughout the Internet or a significant part of it.
*   Local. Local search engines are designed to search for information on any part of the global network, for example, one or more sites, or on a local network. Such search engines are usually used inside private (corporate) networks or in e-commerce systems (online stores).
*   Personal. Personal search engines are used to search among files on personal computers or in small local networks.

According to the data source, search engines are divided into the following groups:

*   Desktop search engines. Desktop search tools search for information on a user's PC, including web browser history, email archives, text documents, sound files, images, and videos.
*   Federated search engines. Federated search is an information retrieval technology that allows user to simultaneously search multiple search resources of different types. The user makes one request, which applies to databases, indexes, or other search engines participating in the federation. The search results are then combined to present to the user. Federated search is used, for example, to integrate disparate information resources within one large organization.
*   Human search engines. The human search engine is a search engine that uses human participation to filter search results and help users refine their search query. The goal is to provide users with a limited number of relevant results, in contrast to traditional search engines, which often return many results, which may or may not be relevant.
*   Metasearch engines. Metasearch engine is a tool for searching information on the Internet, which uses search results of web search engines to get its own results. Metasearch engines receive data from a user and immediately makes requests to search engines. Received results are handled and presented to users.
*   Web search engines. Web search engine is a software system designed to search on the Internet. Search results are usually presented as a set of links to web pages, images, videos, infographics, articles, and other types of files.

By type of content, search engines are divided into:

*   Full text search engines. Full-text search means searching for one or more documents in a full-text database. Each of these documents is a separate file in some format. Full-text search is different from searching by metadata or by parts of original texts presented in databases (such as titles, annotations, individual sections or bibliographic references) and is usually performed across the entire content of each indexed document.
*   Image search engines. The image search engine is a computer system for viewing, searching and retrieving images from a large database of digital images. To be able to search for images, some metadata are added to images specified manually or using image recognition systems.
*   Video search engines. Video search engines are computer programs designed to search for videos stored on digital devices. The search is be performed in indexed metadata that is automatically produced from audiovisual material.

By type of interaction interface, search engines are divided into:

*   Normal search. Normal search involves entering a search query and subsequent retrieval of search results as a list.
*   Incremental search. Incremental search is a type of search interface, which is characterized by the provision of search results to the user in the process of typing a search query. The user can also choose the option of ending his search query from the proposed list.
*   Semantic search. Semantic search refers to search with meaning, in contrast to lexical search, where the search engine searches for literal matches of words or their variants, without understanding the general meaning of the query.
*   Selection-based search. A selection-based search system is a search engine in which a user makes a search query by selecting from the proposed options.
*   Voice search. Voice search is an interface that allows users to enter search queries by speaking them into the microphone of a digital device.

Database management systems are also search engines, because they always have facilities for indexing data and performing searches on them. Various databases differ in the way data is stored and the types of indexes created:

*   Relational database management system. A relational database is a digital database based on the relational or table-oriented model of data.
*   Document store. A document-oriented database is a computer program designed to store, retrieve and manage document-oriented information, also known as semi-structured data.
*   Key-value store. A key-value database is a data storage paradigm for storing, retrieving, and managing associative arrays, as well as a data structure, better known today as a dictionary or hash table.
*   Graph database management system. A graph database is a database that uses graph structures for semantic queries with nodes, edges, and properties to represent and store data.
*   Object database management system. An object database is a database in which information is represented in the form of objects as used in object-oriented programming.
*   Multi-model database management system. A multi-model database management system is a DBMS that provides the ability to store and work with data using various paradigms.

In accordance with the above types of classification, GroupDocs.Search API refers to the following types of search engines:

*   By search area - local or personal full-text search engine.
*   By data source - desktop full-text search index.
*   By type of content - full-text search database. In addition, the API can also extract metadata from image and video files, as well as add arbitrary optional fields to any indexed documents.
*   By the type of interaction interface - normal with the ability to retrieve results by chunks.
*   By type of index - nosql document store database.
