-- example code to import data manually to tables in pgAdmin
COPY public.memes
(
    id,
    name,
    url,
    width,
    height,
    captions
)
FROM 'file path to csv file'
DELIMITER ','
CSV HEADER ESCAPE ''''
FORCE NOT NULL id, name, url;