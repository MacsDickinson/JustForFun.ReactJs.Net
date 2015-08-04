var RecipeList = React.createClass({
    loadRecipesFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },
    getInitialState: function () {
        return { data: this.props.initialData };
    },
    componentDidMount: function () {
        window.setInterval(this.loadRecipesFromServer, this.props.pollInterval);
    },
    render: function () {
        var recipeNodes = this.state.data.map(function (recipe) {
            return (
              <RecipeCard data={recipe}></RecipeCard>
          );
        });
        return React.createElement('div', { className: "recipeList ui link cards" },
        { recipeNodes }
      )
    }
});

var RecipeCard = React.createClass({
    render: function () {
        var recipe = this.props.data;
        if (!recipe.ImageUrl) {
            recipe.ImageUrl = "http://semantic-ui.com/images/wireframe/image.png";
        }
        recipe.Url = '/recipe/' + recipe.Id

        return (<div className="card">
        <a className="content">
            <img className="ui avatar image" src="http://semantic-ui.com/images/avatar/large/elliot.jpg" /> Author Name
        </a>
        <a className="image" href={recipe.Url}>
            <img src={recipe.ImageUrl} alt={recipe.Name} />
        </a>
        <div className="content">
            <a className="header" href={recipe.Url}>{recipe.Name}</a>
            <div className="description">
                {recipe.Intro}
            </div>
        </div>
        <div className="extra content">
            <span className="right floated">
              <i className="heart outline like icon"></i> 17 likes
            </span>
            <i className="comment icon"></i> 3 comments
        </div>
        </div>)
    }
});

var RecipeDetails = React.createClass({
    loadRecipeFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest')
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },
    getInitialState: function () {
        if (this.props.initialData) {
            return { data: this.props.initialData };
        }
        return null;
    },
    componentDidMount: function () {
        if (!this.state) {
            this.loadRecipeFromServer();
        }
    },
    render: function () {

        if (!this.state) {
            return (
            <div className="ui active inverted dimmer">
                <div className="ui text loader">Loading</div>
            </div>)
        }

        var recipe = this.state.data;
        if (!recipe.ImageUrl) {
            recipe.ImageUrl = "http://semantic-ui.com/images/wireframe/image.png";
        }

        var ingrediantNodes = recipe.Ingredients.map(function (ingrediant) {
                return (
                  <li>{ingrediant.Quantity} {ingrediant.ProduceName}</li>
              );
        });
        var directionsNodes = recipe.Directions.map(function (direction) {
                return (
                  <li>{direction}</li>
              );
        });

        var converter = new Showdown.converter();
        var rawDescription = converter.makeHtml(recipe.Description.toString());

        return(
            <div className="ui raised very padded text container extra-margin--top">
                <h2 className="ui center aligned header">
                    <div className="content">
                        {recipe.Name}
                        <div className="sub header">Serves: {recipe.Servings}</div>
                    </div>
                </h2>
                <div className="ui comments">
                    <div className="comment">
                        <a className="avatar">
                            <img src="http://semantic-ui.com/images/avatar/large/elliot.jpg" />
                        </a>
                        <div className="content">
                            Author Name
                            <div className="metadata">
                                <div className="date">2 days ago</div>
                                <div className="rating">
                                    <i className="star icon"></i>
                                    5 Faves
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="ui piled segment">
                    <img className="ui left floated image" src={recipe.ImageUrl} alt={recipe.Name} />
                    <p dangerouslySetInnerHTML={{__html: rawDescription }}></p>
                    <h2>Ingrediants</h2>
                    <ul>{ingrediantNodes}</ul>
                    <h2>Directions</h2>
                    <ol>{directionsNodes}</ol>

                </div>
            </div>)
    }
});

//var elementId = 'recipe-details'

//if (document.getElementById(elementId)) {
//    React.render(
//      <RecipeDetails url="/recipe/kid-friendly-green-juice-recipe" />,
//      document.getElementById(elementId)
//    );
//}

